using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using OA.DataAccess;
using OA.Domain.Requests;
using OA.Domin.Administration;
using OA.Domin.AutoMapper;
using OA.Domin.Logging;
using OA.Domin.Requests;
using OA.Domin.Responces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OA.Services.Administration
{
    public class AdministrationService : IAdministrationService
    {
        private readonly UserManager<User> UserManager;
        private readonly RoleManager<IdentityRole> RoleManager;

        private readonly AppDbContext dbContext;
        public AdministrationService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, AppDbContext dbContext)
        {
            this.UserManager = userManager;
            this.RoleManager = roleManager;
            this.dbContext = dbContext;
        }

        #region "Users Managment"
        public async Task<Response<CustomUser>> AddUserAsync(CustomUser user)
        {
            Response<CustomUser> result = new Response<CustomUser>();

            var existedUser = dbContext.Users.Where(u => u.Email == user.Email || u.UserName == user.UserName).FirstOrDefault();
            if (existedUser != null)
            {
                var emailValidation = new ValidationResult()
                {
                    Field = "Email",
                    Errors = new List<string>() { "Email or User Name Already Existed" }
                };
                result.Result = null;
                result.HasErrors = true;
                result.ValidationErrors.Add(emailValidation);

                return result;
            }
            var newUser = new User { Email = user.Email, UserName = user.UserName, ConfirmedAccount = user.ConfirmedAccount };
            var createdUser = await UserManager.CreateAsync(newUser, user.Password);
            if (!createdUser.Succeeded)
            {
                var PasswordValidation = new ValidationResult();
                PasswordValidation.Field = "User";
                foreach (var err in createdUser.Errors)
                    PasswordValidation.Errors.Add(err.Description);

                result.Result = null;
                result.HasErrors = true;
                result.ValidationErrors.Add(PasswordValidation);

                return result;
            }

            //Edit Created User (phone, user name, confirmed)
            newUser.ConfirmedAccount = true;
            newUser.PhoneNumber = user.Phone;
            newUser.Email = user.Email;
            newUser.NormalizedEmail = user.Email?.ToUpper();
            dbContext.Entry(newUser).State = EntityState.Modified;
            dbContext.SaveChanges();

            //Assign Roles To User
            user.Id = newUser.Id;
            SetUserRoles(user);

            result.Result = user;

            return result;

        }

        public Response<CustomUser> UpdateUser(CustomUser user)
        {
            Response<CustomUser> result = new Response<CustomUser>();

            var identityUser = dbContext.Users.Find(user.Id);

            if (user.Email != identityUser.Email)
            {
                //Check Email Address
                var existedUser = dbContext.Users.Where(u => u.Email == user.Email || u.UserName == user.UserName).FirstOrDefault();
                if (existedUser != null)
                {
                    var emailValidation = new ValidationResult()
                    {
                        Field = "Email",
                        Errors = new List<string>() { "Email or User Name Already Existed" }
                    };
                    result.Result = null;
                    result.HasErrors = true;
                    result.ValidationErrors.Add(emailValidation);

                    return result;
                }
            }

            identityUser.PhoneNumber = user.Phone;
            identityUser.UserName = user.UserName;
            identityUser.NormalizedUserName = user.UserName.ToUpper();
            identityUser.Email = user.Email;
            identityUser.NormalizedEmail = user.Email.ToUpper();
            dbContext.Entry(identityUser).State = EntityState.Modified;
            dbContext.SaveChanges();


            //Set User Roles
            SetUserRoles(user);

            result.Result = user;
            return result;

        }

        public void DeleteUser(string userId)
        {
            var user = dbContext.Users.Find(userId);
            if (user != null)
            {
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }
        }

        public async Task<Response<ResetPasswordRequest>> ResetPassword(ResetPasswordRequest reset)
        {
            
            Response<ResetPasswordRequest> result = new Response<ResetPasswordRequest>();

            var changeResult = await ChangeUserPassword(reset.Id, reset.Password);
            if (changeResult.HasErrors)
            {
                result.HasErrors = true;
                result.ValidationErrors = changeResult.ValidationErrors;
                return result;
            }

            result.Result = reset;
            return result;

        }

        private async Task<Response<string>> ChangeUserPassword(string userId, string password)
        {
            Response<string> result = new Response<string>();

            var passwordValidator = new PasswordValidator<User>();
            var passResult = await passwordValidator.ValidateAsync(UserManager, null, password);

            if (!passResult.Succeeded)
            {
                var PasswordValidation = new ValidationResult();
                PasswordValidation.Field = "User";
                foreach (var err in passResult.Errors)
                    PasswordValidation.Errors.Add(err.Description);

                result.HasErrors = true;
                result.ValidationErrors.Add(PasswordValidation);

                return result;
            }

            var identityuser = dbContext.Users.Find(userId);
            var passwordHash = UserManager.PasswordHasher.HashPassword(identityuser, password);

            identityuser.PasswordHash = passwordHash;
            identityuser.LastPasswordChange = DateTime.Now;
            identityuser.FirstUse = false;
            dbContext.Entry(identityuser).State = EntityState.Modified;
            dbContext.SaveChanges();

            result.Result = password;
            return result;
        }

        public async Task<IEnumerable<CustomUser>> GetAllUsers()
        {
            var identityUsers = await dbContext.Users.OrderBy(u => u.UserName).ToListAsync();
            var users = new List<CustomUser>();
            foreach (var identityUser in identityUsers)
            {
                var user = new CustomUser() { Id = identityUser.Id, UserName = identityUser.UserName, Email = identityUser.Email };

                //user.Roles = 

                users.Add(user);
            }
            return users;
        }

        public async Task<User> GetById(string userId)
        {
            return await UserManager.FindByIdAsync(userId);
        }

        public CustomUser GetUserById(string userId)
        {
            var user = dbContext.Users.Find(userId);
            //var customUser = Mapping.Mapper.Map<CustomUser>(user);
            var customUser = new CustomUser()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Phone = user.PhoneNumber,
                Password = user.PasswordHash,
                ConfirmPassword = user.PasswordHash,
                Roles = GetUserRoles(user.Id),
                //Claims = await UserManager.GetClaimsAsync(user)
            };

            return customUser;
        }

        public IEnumerable<CustomUser> GetClaimUsers(string claim)
        {
            var query =
                from users in dbContext.Users
                    join userRoles in dbContext.UserRoles on users.Id equals userRoles.UserId
                    join roleClaims in dbContext.RoleClaims on userRoles.RoleId equals roleClaims.RoleId
                where roleClaims.ClaimValue == claim
                select new CustomUser {
                    Id = users.Id,
                    Email = users.Email,
                    UserName = users.UserName,
                };

            return query.ToList();
        }

        public IEnumerable<SignupRequest> GetUnProcessedSignupRequests()
        {
            return dbContext.SignupRequests.Where(s => s.Confirmed == null).ToList();
        }

        public SignupRequest ChangeSignUpRequestState(SignupRequest request)
        {
            var user = dbContext.Users.Find(request.UserId);
            if (user != null)
            {
                user.ConfirmedAccount = (bool)request.Confirmed;
                dbContext.Entry(user).State = EntityState.Modified;
                dbContext.SaveChanges();
            }


            dbContext.Entry(request).State = EntityState.Modified;
            dbContext.SaveChanges();

            return request;
        }

        public void AddUserVerificationAnswers(IEnumerable<UserVerificationAnswerCreateRequest> userVerificationAnswers, string userId)
        {
            foreach (var answer in userVerificationAnswers)
                dbContext.UserVerificationAnswers.Add(new UserVerificationAnswer 
                { 
                    UserId = userId, 
                    VerificationQuestionId = answer.VerificationQuestionId,
                    Answer = answer.Answer
                });

            dbContext.SaveChanges();
        }

        public IEnumerable<VerificationQuestion> GetVerificationQuestions()
        {
            return dbContext.VerificationQuestions.ToList();
        }
        public Response<IEnumerable<VerificationQuestion>> GetUserVerificationQuestions(string email)
        {
            var response = new Response<IEnumerable<VerificationQuestion>>();

            var user = dbContext.Users.FirstOrDefault(u => u.Email == email);

            if(user == null)
            {
                response.HasErrors = true;
                response.AddValidationError("Email", "No user found with the given email");
                return response;
            }

            var userVerificationQuestions = dbContext.UserVerificationAnswers
                                                     .Where(uv => uv.UserId == user.Id)
                                                     .Select(uv => uv.VerificationQuestion)
                                                     .ToList();
            if (!userVerificationQuestions.Any())
            {
                response.HasErrors = true;
                response.AddValidationError("Verification Questions", "No verification questions found for the given user");
                return response;
            }

            response.Result = userVerificationQuestions;
            return response;
            
        }
        public async Task<Response<string>> ExternalResetPassword(ExternalResetPasswordRequest externalResetPasswordRequest)
        {
            var response = new Response<string>();

            var user = dbContext.Users.FirstOrDefault(u => u.Email == externalResetPasswordRequest.Email);
            if (user == null)
            {
                response.HasErrors = true;
                response.AddValidationError("Email", "No user found with the given email");
                return response;
            }

            var verifyResult = VerifyQuestions(externalResetPasswordRequest.UserVerificationAnswers, user.Id);
            if (!verifyResult)
            {
                response.HasErrors = true;
                response.AddValidationError("Verification Questions", "Verification Questions Answers not matched");
                return response;
            }

            var changeResult = await ChangeUserPassword(user.Id, externalResetPasswordRequest.Password);

            return changeResult;
        }

        private bool VerifyQuestions(List<UserVerificationAnswerCreateRequest> userVerificationAnswers, string userId)
        {
            var userAnswers = dbContext.UserVerificationAnswers.Where(v => v.UserId == userId).ToList();

            foreach(var userAnswer in userAnswers)
            {
                var matchAnswer = userVerificationAnswers.First(a => a.VerificationQuestionId == userAnswer.VerificationQuestionId);

                if (matchAnswer == null || userAnswer.Answer != matchAnswer.Answer)
                    return false;
            }

            return true;
        }

        #endregion


        #region "Roles Managment"
        public IEnumerable<CustomRole> GetAllRoles()
        {
            var roles = dbContext.Roles.ToList();

            var customRoles = new List<CustomRole>();

            foreach (var role in roles)
                customRoles.Add(new CustomRole() { Name = role.Name, Id = role.Id });

            return customRoles;

        }

        public CustomRole GetRole(string roleId)
        {
            var role = dbContext.Roles.Find(roleId);
            var customRole = new CustomRole
            {
                Id = role.Id,
                Name = role.Name,
                Claims = GetRoleClaims(role.Id)
            };

            return customRole;
        }

        public CustomRole GetRoleByName(string roleName)
        {
            var role = dbContext.Roles.Where(r => r.Name == roleName).FirstOrDefault();

            if (role != null)
            {
                var customRole = new CustomRole
                {
                    Id = role.Id,
                    Name = role.Name,
                    Claims = GetRoleClaims(role.Id)
                };

                return customRole;
            }

            return null;

        }

        public CustomRole GetClaimRole(string claimVal)
        {
            var roleClaim = dbContext.RoleClaims.Where(c => c.ClaimValue == claimVal).ToList().FirstOrDefault();
            if (roleClaim != null)
                return GetRole(roleClaim.RoleId);

            return null;
        }

        public Response<CustomRole> CreateRole(CustomRole role)
        {
            Response<CustomRole> response = new Response<CustomRole>();
            var existed = dbContext.Roles.Where(r => r.Name == role.Name).FirstOrDefault();
            if (existed != null)
            {
                response.HasErrors = true;
                response.ValidationErrors.Add(new ValidationResult { Field = "Role Name", Errors = { "Role with the same name already existed" } });
                return response;
            }
            if (string.IsNullOrEmpty(role.Name))
            {
                response.HasErrors = true;
                response.ValidationErrors.Add(new ValidationResult { Field = "Role Name", Errors = { "Role Name can not be empty" } });
                return response;
            }

            var createdRole = new IdentityRole { Name = role.Name };
            dbContext.Roles.Add(createdRole); ;
            dbContext.SaveChanges();

            role.Id = createdRole.Id;
            SetRoleClaims(role);

            response.HasErrors = false;
            response.Result = role;
            return response;
        }

        public Response<CustomRole> UpdateRole(CustomRole role)
        {
            Response<CustomRole> response = new Response<CustomRole>();

            var irole = dbContext.Roles.Find(role.Id);

            if (irole.Name != role.Name)
            {
                var existed = dbContext.Roles.Where(r => r.Name == role.Name && r.Id != role.Id).FirstOrDefault();
                if (existed != null)
                {
                    response.HasErrors = true;
                    response.ValidationErrors.Add(new ValidationResult { Field = "Role Name", Errors = { "Role with the same name already existed" } });
                    return response;
                }
                if (string.IsNullOrEmpty(role.Name))
                {
                    response.HasErrors = true;
                    response.ValidationErrors.Add(new ValidationResult { Field = "Role Name", Errors = { "Role Name can not be empty" } });
                    return response;
                }

                irole.Name = role.Name;
                dbContext.Entry(irole).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            SetRoleClaims(role);

            response.HasErrors = false;
            response.Result = role;
            return response;
        }

        public void DeleteRole(string roleId)
        {
            var role = dbContext.Roles.Find(roleId);
            if (role != null)
            {
                dbContext.Roles.Remove(role);
                dbContext.SaveChanges();
            }

        }

        #endregion

        #region "User-Role Managment"
        public void AddRoleToUser(string roleId, string userId)
        {
            //string guid = Guid.NewGuid().ToString();
            dbContext.UserRoles.Add(new IdentityUserRole<string>() { UserId = userId, RoleId = roleId });
            dbContext.SaveChanges();
        }

        public void RemoveRoleFromUser(string roleId, string userId)
        {
            var userRole = dbContext.UserRoles.Where(ur => ur.RoleId == roleId && ur.UserId == userId).FirstOrDefault();
            if (userRole != null)
            {
                dbContext.UserRoles.Remove(userRole);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<CustomRole> GetUserRoles(string userId)
        {
            var result = new List<CustomRole>();

            var userRoles = dbContext.UserRoles.Where(ur => ur.UserId == userId).ToList();
            foreach (var userRole in userRoles)
            {
                var role = dbContext.Roles.Find(userRole.RoleId);
                result.Add(new CustomRole() { Id = role.Id, Name = role.Name });
            }

            return result;

        }

        public void SetUserRoles(CustomUser user)
        {

            var allRoles = GetAllRoles().Select(x => x.Id);
            var selectedRoles = user.Roles.Select(x => x.Id);
            var userCurrentRoles = GetUserRoles(user.Id).Select(x => x.Id);

            foreach (var roleId in allRoles)
            {
                if (selectedRoles.Contains(roleId) && !userCurrentRoles.Contains(roleId))
                    AddRoleToUser(roleId, user.Id);
                if (!selectedRoles.Contains(roleId) && userCurrentRoles.Contains(roleId))
                    RemoveRoleFromUser(roleId, user.Id);
            }

        }
        #endregion


        #region "Role-Claim Managment"

        public IEnumerable<PermissionClaim> GetPermissionClaims()
        {
            return dbContext.PermissionClaims.ToList();
        }

        public string GetUserFilterdClaim(string userId, string filter, Func<string, string, bool> filterFunc)
        {
            var query =
                from userRoles in dbContext.UserRoles
                    join roleClaims in dbContext.RoleClaims on userRoles.RoleId equals roleClaims.RoleId
                where userRoles.UserId == userId
                select roleClaims.ClaimValue;

            var claims = query.ToList();
            
            var claim = claims.FirstOrDefault(c => filterFunc(c, filter));

            return claim;
        }

        public IEnumerable<PermissionClaim> GetRoleClaims(string roleId)
        {
            var permissionClaims = new List<PermissionClaim>();

            var roleClaims = dbContext.RoleClaims.Where(rc => rc.RoleId == roleId).ToList();
            foreach(var roleClaim in roleClaims)
            {
                var permissionClaim = dbContext.PermissionClaims.Find(roleClaim.ClaimValue);
                permissionClaims.Add(permissionClaim);
            }
            return permissionClaims;
        }

        public void SetRoleClaims(CustomRole role)
        {
            var allPermissionClaims = GetPermissionClaims().Select(x => x.Value);
            var selectedPermissions = role.Claims.Select(x => x.Value);
            var roleCurrentPermissions = dbContext.RoleClaims.Where(rc => rc.RoleId == role.Id).ToList().Select(x => x.ClaimValue);

            foreach (var perClaimVal in allPermissionClaims)
            {
                if (selectedPermissions.Contains(perClaimVal) && !roleCurrentPermissions.Contains(perClaimVal))
                    AddClaimToRole(perClaimVal, role.Id);
                if (!selectedPermissions.Contains(perClaimVal) && roleCurrentPermissions.Contains(perClaimVal))
                    RemoveClaimFromRole(perClaimVal, role.Id);
            }
        }

        public void AddClaimToRole(string perClaimVal, string roleId)
        {
            dbContext.RoleClaims.Add(new IdentityRoleClaim<string> { RoleId = roleId, ClaimValue = perClaimVal, ClaimType = "Permission" });
            dbContext.SaveChanges();
        }

        public void RemoveClaimFromRole(string perClaimVal, string roleId)
        {
            var roleClaim = dbContext.RoleClaims.Where(rc => rc.RoleId == roleId && rc.ClaimType == "Permission" && rc.ClaimValue == perClaimVal).FirstOrDefault();
            if (roleClaim != null) {
                dbContext.RoleClaims.Remove(roleClaim);
                dbContext.SaveChanges();
            }
        }

        #endregion

        public async Task<IEnumerable<Claim>> GetUserClaims(string userId)
        {
            var user = dbContext.Users.Find(userId);
            return await UserManager.GetClaimsAsync(user);
        }
       
        public Task AddClaimToUser(string claimId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveClaimFromUser(string claimId, string userId)
        {
            throw new NotImplementedException();
        }


    }
}
