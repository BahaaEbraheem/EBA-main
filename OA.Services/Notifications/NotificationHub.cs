using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using OA.DataAccess;
using OA.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Services.Notifications
{
    public class NotificationHub : Hub
    {
        private readonly JwtSettings jwtSettings;
        private readonly AppDbContext dbContext;

        public NotificationHub(JwtSettings jwtSettings, AppDbContext dbContext)
        {

            this.jwtSettings = jwtSettings;
            this.dbContext = dbContext;
            
        }

        public override Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var token = httpContext.Request.Query["access_token"];
            var userId = TryGetUserFromJwtToken(token);

            if (!string.IsNullOrEmpty(userId))
            {
                string connectionId = Context.ConnectionId;

                //Add Each User To Group
                Groups.AddToGroupAsync(connectionId, userId);

                //Add Each User To his Role Group
                var userRoles = dbContext.UserRoles.Where(ur => ur.UserId == userId).ToList();
                userRoles.ForEach(ur => Groups.AddToGroupAsync(connectionId, ur.RoleId));

                return base.OnConnectedAsync();
            }
            return Task.CompletedTask;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var httpContext = Context.GetHttpContext();
            var token = httpContext.Request.Query["access_token"];
            var userId = TryGetUserFromJwtToken(token);

            if (!string.IsNullOrEmpty(userId))
            {
                string connectionId = Context.ConnectionId;

                //Add Each User To Group
                Groups.RemoveFromGroupAsync(connectionId, userId);

                //Add Each User To his Role Group
                var userRoles = dbContext.UserRoles.Where(ur => ur.UserId == userId).ToList();
                userRoles.ForEach(ur => Groups.RemoveFromGroupAsync(connectionId, ur.RoleId));
            }


            return base.OnDisconnectedAsync(exception);
        }


        private string TryGetUserFromJwtToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(jwtSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new SecurityTokenException("Invalid token");
                }

                string userId = jwtToken.Claims.First(x => x.Type == "Id").Value;

                return userId;
            }
            catch
            {
                return "";
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}
