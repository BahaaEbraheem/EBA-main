using Microsoft.AspNetCore.Identity;
using OA.Domain.Responces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using OA.Domain.Settings;
using OA.Domin.Administration;
using OA.Services.Administration;
using OA.DataAccess;
using System.Security.Cryptography;
using OA.Domin.Requests;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using OA.Services.Notifications;
using OA.Domin.Notifications;
using OA.Domain.Requests;

namespace OA.Services.Auth
{
    public class IdentityService : IIdentityService
    {

        private readonly UserManager<User> userManager;
        private readonly JwtSettings jwtSettings;
        private readonly AppDbContext dbContext;
        private readonly INotificationService notificationService;
        private readonly IAdministrationService administrationService;
        private readonly ISMSService SMSService;

        public IdentityService(UserManager<User> userManager, 
                               JwtSettings jwtSettings, 
                               AppDbContext dbContext,
                               INotificationService notificationService,
                               IAdministrationService administrationService,
                               ISMSService SMSService)
        {
            this.userManager = userManager;
            this.jwtSettings = jwtSettings;
            this.dbContext = dbContext;
            this.notificationService = notificationService;
            this.administrationService = administrationService;
            this.SMSService = SMSService;
        }

        public async Task<AuthResult> RegisterAsync(RegisterRequest registerRequest)
        {
            var userName = registerRequest.UserName;
            var pUserName = userName.Replace(" ", "").ToLower();
            var email = $"{pUserName}@app.com";
            var password = registerRequest.Password;

            AuthResult authResult = new AuthResult();

            //If Registration App Setting is off
            var regSetting = dbContext.AppSettings.Find("Registration");
            if (regSetting != null && regSetting.Value == "false")
            {
                authResult.Successed = false;
                authResult.Errors = new List<string>() { "Registration Is Disabled By Admin" };
                return authResult;
            }

            var existedUser = dbContext.Users.AsNoTracking().FirstOrDefault(u => u.UserName == userName);
            if (existedUser != null)
            {
                return new AuthResult {Successed = false, Errors = new List<string>{ "This User Name Address Already Existed" } };
            }

            var newUser = new User { Email = email, UserName = email, ConfirmedAccount = true };

            var createdUser = await userManager.CreateAsync(newUser, password);

            if (!createdUser.Succeeded)
            {
                return new AuthResult() { Successed = false, Errors = createdUser.Errors.Select(x => x.Description) };
            }

            authResult.Successed = true;
            return authResult;
            //var token = GenerateUserJwtToken(newUser);
            //var refreshToken = GenerateRefreshToken();

            ////Set Refresh Token To User
            //newUser.RefreshTokn = refreshToken;
            //newUser.RefreshTokenExpiryTime = DateTime.Now.AddDays(Convert.ToDouble(jwtSettings.RefreshExpiresInDays));
            //await userManager.UpdateAsync(newUser);

            //if (token != "")
            //{
            //    authResult.Successed = true;
            //    authResult.Token = token;
            //    authResult.RefreshToken = refreshToken;                
            //    return authResult;
            //}
            //return new AuthResult() { Successed = false, Errors = new List<string>() { "Faild To Register User" } };
        }

        public async Task<AuthResult> CustomerRegister(CustomerRegisterRequest registerRequest)
        {
            var userName = registerRequest.UserName;
            var pUserName = userName.Replace(" ", "").ToLower();
            var email = $"{pUserName}@app.com";
            
            var generatedPassword = $"Auto_{pUserName.ToLower()}@123";

            var existedUser = dbContext.Users.AsNoTracking().FirstOrDefault(u => u.UserName == userName);
            if (existedUser != null)
            {
                return new AuthResult { Errors = new List<string> { "Try another user name" } };
            }

            var newUser = new User { Email = email, UserName = userName, ConfirmedAccount = true };

            var createdUser = await userManager.CreateAsync(newUser, generatedPassword);

            var authResult = new AuthResult();

            if (!createdUser.Succeeded)
            {
                authResult.Successed = false;
                authResult.Errors = createdUser.Errors.Select(x => x.Description);
                return authResult;
            }

            var customerRole = dbContext.RoleClaims.FirstOrDefault(rc => rc.ClaimValue == "position-customer");
            
            if (customerRole == null)
            {
                authResult.Successed = false;
                authResult.Errors = new List<string> { "Faild to assign the customer role (contact system administrator)" };
                return authResult;
            }

            dbContext.UserRoles.Add(new IdentityUserRole<string>() { UserId = newUser.Id, RoleId = customerRole.RoleId });
            dbContext.SaveChanges();

            //Add Verification Questions User Answeers
            if(registerRequest.UserVerificationAnswers != null && registerRequest.UserVerificationAnswers.Any())
                administrationService.AddUserVerificationAnswers(registerRequest.UserVerificationAnswers, newUser.Id);

            //Send The Password By SMS Message
            _ = SMSService.SendMsg("Madarat", registerRequest.MobileNumber, generatedPassword);

            authResult.Successed = true;
            authResult.Token = "";
            authResult.RefreshToken = "";
            authResult.Errors = null;

            return authResult;

            //return new AuthResult();
        }

        public async Task<AuthResult> LoginAsync(LoginRequest loginRequest)
        {
            var email = loginRequest.Email;
            var userName = loginRequest.UserName;
            var password = loginRequest.Password;

            //var user = await userManager.FindByEmailAsync(email);
            var user = await userManager.FindByNameAsync(userName);
            if (user != null)
            {
                var valid = await userManager.CheckPasswordAsync(user, password);
                if (valid)
                {
                    AuthResult authResult = new AuthResult();

                    //Check If Register Confirmation Setting is on
                    authResult = ConfirmationCheck(user);
                    if (authResult != null) 
                        return authResult; 
                    else 
                        authResult = new AuthResult();

                    var token = GenerateUserJwtToken(user);
                    var refreshToken = GenerateRefreshToken();

                    //Set Refresh Token To User
                    user.RefreshTokn = refreshToken;
                    user.RefreshTokenExpiryTime = DateTime.Now.AddDays(Convert.ToDouble(jwtSettings.RefreshExpiresInDays));
                    await userManager.UpdateAsync(user);

                    if (token != "")
                    {
                        authResult.Successed = true;
                        authResult.Token = token;
                        authResult.RefreshToken = refreshToken;
                        authResult.ProfilePic = user.ProfilePic;
                        return authResult;
                    }
                    return new AuthResult() { Successed = false, Errors = new List<string>() { "Faild To Login" } };
                }
            }

            return new AuthResult { Errors = new string[] { "Invalid Login Data" } };
        }

        public AuthResult RefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            if (refreshTokenRequest == null)
                return new AuthResult { Successed = false, Errors = new List<string>() { "Invalid Client Request" } };

            string userId = GetUserIdFromExpiredToken(refreshTokenRequest.Token);
            var user = dbContext.Users.Find(userId);

            if (user == null ||
               user.RefreshTokn != refreshTokenRequest.RefreshToken)
            {
                return new AuthResult { Successed = false, Errors = new List<string>() { "Invalid Client Request" } };
            }
            if(user.RefreshTokenExpiryTime < DateTime.Now)
            {
                return new AuthResult { Successed = false, Errors = new List<string>() { "Refresh Token Expired" } };
            }

            var token = GenerateUserJwtToken(user);
            var refreshtoken = GenerateRefreshToken();

            user.RefreshTokn = refreshtoken;
            dbContext.Entry(user).State = EntityState.Modified;
            dbContext.SaveChanges();

            return new AuthResult()
            {
                Successed = true,
                Token = token,
                RefreshToken = user.RefreshTokn
            };

        }


        public async Task<AuthResult> RegisterRequest(RegisterRequest registerRequest)
        {
            var email = registerRequest.Email;
            var password = registerRequest.Password;

            var existedUser = await userManager.FindByEmailAsync(email);
            if (existedUser != null)
            {
                return new AuthResult { Errors = new List<string>{ "This Email Address Already Existed" } };
            }

            var newUser = new User { Email = email, UserName = email };

            var createdUser = await userManager.CreateAsync(newUser, password);

            if (!createdUser.Succeeded)
            {
                return new AuthResult() { Errors = createdUser.Errors.Select(x => x.Description) };
            }

            //Add Signup Request
            dbContext.SignupRequests.Add(new SignupRequest { UserId = newUser.Id, Email = newUser.Email, Confirmed = null });

            if (registerRequest.IsCustomer)
            {
                var customerRole = dbContext.RoleClaims.FirstOrDefault(rc => rc.ClaimValue == "position-customer");

                if (customerRole == null)
                {
                    throw new Exception("Cant Fint a Customer Role");
                }

                dbContext.UserRoles.Add(new IdentityUserRole<string>() { UserId = newUser.Id, RoleId = customerRole.RoleId });
            }

            dbContext.SaveChanges();

            //Send Notification To Admins
            var AdminRole = dbContext.Roles.Where(r => r.Name == "Admin").FirstOrDefault();
            if (AdminRole != null)
                await notificationService.PushToRoleGroup(AdminRole.Id, new Notification { Title = "New Registration Request", Body = "go to administration registration requests to process the request" });

            return new AuthResult() 
            { 
                Successed = true
            };
        }


        private AuthResult ConfirmationCheck(User user)
        {
            //Check If Register Confirmation Setting is on
            var registerConfirmation = dbContext.AppSettings.Find("RegistrationAdminConfirm");
            if (registerConfirmation != null && registerConfirmation.Value == "true" && !user.ConfirmedAccount)
            {
                if (!IsAdmin(user))
                {
                    List<string> errors = new List<string>();
                    var userRequest = dbContext.SignupRequests.Where(s => s.UserId == user.Id).FirstOrDefault();
                    if (userRequest != null)
                    {
                        if (userRequest.Confirmed == null)
                            errors.Add("Your Registration Request Hasn't Been Processed Yet .. Try Later");
                        else if (userRequest.Confirmed == false)
                        {
                            errors.Add("Your Registration Request Has Been Declined");
                            errors.Add($"Reason : {userRequest.Reason}");

                            //Delete The Request (Optional)
                            //dbContext.SignupRequests.Remove(userRequest);
                            //dbContext.SaveChanges();
                        }
                    }
                    else
                    {
                        errors.Add("There is a problem with your registration request .. try register again");

                        //Delete The User (Optional)
                        //dbContext.Users.Remove(user);
                        //dbContext.SaveChanges();
                    }

                    return new AuthResult
                    {
                        Successed = false,
                        Errors = errors
                    };
                }
            }
            return null;
        } 

        private string GenerateUserJwtToken(User user)
        {
            try
            {
                var signingCredentials = GetSigningCredentials();
                var claims = GetClaims(user.Id);
                var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return token;
            }
            catch (Exception)
            {
                //Log The Exception
                return "";
            }  
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(jwtSettings.Secret);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private List<Claim> GetClaims(string userId)
        {
            var user = dbContext.Users.Find(userId);

            //Basic Claims
            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("UserName", user.UserName),
                new Claim("FirstUse", user.FirstUse.ToString()),
                new Claim("LastPasswordChange", user.LastPasswordChange.ToString()),
                new Claim("ShouldChangePassword", ShouldChangePassword(user.LastPasswordChange).ToString())
            };

            //Role Claims
            var userRoles = dbContext.UserRoles.Where(ur => ur.UserId == userId).ToList();
            foreach (var userRole in userRoles) {
                var role = dbContext.Roles.Find(userRole.RoleId);
                claims.Add(new Claim(ClaimTypes.Role, role.Name));

                //Role Premission Claims
                var roleClaims = dbContext.RoleClaims.Where(rc => rc.RoleId == role.Id).ToList();
                foreach(var roleClaim in roleClaims)
                    claims.Add(new Claim(roleClaim.ClaimType, roleClaim.ClaimValue));
                
            }


            return claims;

        }

        private bool ShouldChangePassword(DateTime? lastChange)
        {
            var daysToChange = dbContext.AppSettings.Find("ForceChangePasswordEvery");

            if (daysToChange == null || daysToChange.Value == "0")
                return false;

            if (lastChange == null)
                return true;

            var days = Convert.ToInt32(daysToChange.Value);
            var changeDate = lastChange.Value.AddDays(days);

            return DateTime.Now > changeDate;            
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                //issuer: jwtSettings.issuar,
                //audience: jwtSettings.validAudience,
                claims: claims,
                expires: DateTime.Now.AddHours(Convert.ToDouble(jwtSettings.ExpiresInHours)),
                signingCredentials: signingCredentials
            );

            return tokenOptions;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            var rng = RandomNumberGenerator.Create();
            
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
            
        }

        private string GetUserIdFromExpiredToken(string token)
        {
            try
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                    ValidateLifetime = false,
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken securityToken;

                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

                var jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new SecurityTokenException("Invalid token");
                }

                string userId = principal.Claims.First(x => x.Type == "Id").Value;

                return userId;
            }
            catch(Exception e)
            {
                var msg = e.Message;
                return "";
            }

        }

        private bool IsAdmin(User user)
        {
            var userRoles = dbContext.UserRoles.Where(ur => ur.UserId == user.Id).ToList();

            foreach (var userRole in userRoles)
            {
                var role = dbContext.Roles.Find(userRole.RoleId);
                if (role.Name == "Admin")
                    return true;
            }

            return false;
           
        }

    }
}
