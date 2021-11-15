using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OA.DataAccess;
using OA.Domin.Administration;
using OA.Domin.Settings;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /*
     this controller for testing purposes only
     **/
    public class SeedDataController : ControllerBase
    {
        private readonly AppDbContext DbContext;
        private readonly UserManager<User> UserManager;
        public SeedDataController(AppDbContext dbContext, UserManager<User> userManager)
        {
            DbContext = dbContext;
            UserManager = userManager;
        }

        //Seed Admin User With Admin Role    
        [HttpGet("SeedUser")]
        public async Task<IActionResult> SeedUser()
        {
            var adminEmail = "Admin@app.com";
            var adminUserName = "Administrator";
            var existed = DbContext.Users.FirstOrDefault(c => c.UserName == adminUserName);

            if (existed != null)
                return Ok();

            var adminUser = new User
            {
                Email = adminEmail,
                UserName = adminUserName
            };

            var adminPassword = "Admin@123";

            var result = await UserManager.CreateAsync(adminUser, adminPassword);
            if (result.Succeeded)
            {
                DbContext.Roles.Add(new IdentityRole() {Name = "Admin", NormalizedName = "ADMIN" } );
                DbContext.SaveChanges();

                await UserManager.AddToRoleAsync(adminUser, "Admin");
            }

            return Ok();

        }

        [HttpGet("SeedAppSettigs")]
        public IActionResult SeedAppSettigs()
        {
            var existed = DbContext.AppSettings.FirstOrDefault();

            if(existed == null)
            {
                var appSettings = new List<AppSetting>
                {
                    new AppSetting { Key = "ForceChangePasswordEvery", Value = "0" },
                    new AppSetting { Key = "ForceChangePasswordFirstUse", Value = "false" },
                    new AppSetting { Key = "PasswordChangePoicy", Value = "false" },
                    new AppSetting { Key = "Profiling", Value = "true" },
                    new AppSetting { Key = "Registration", Value = "true" },
                    new AppSetting { Key = "RegistrationAdminConfirm", Value = "false" },
                    new AppSetting { Key = "ResetPasswordPassed", Value = "false" },
                };

                DbContext.AppSettings.AddRange(appSettings);
                DbContext.SaveChanges();
            }

            return Ok();
        }

        [HttpGet("SeedPermissions")]
        public IActionResult SeedPermissions()
        {
            var existed = DbContext.PermissionClaims.FirstOrDefault();

            if(existed == null)
            {
                var permissions = new List<PermissionClaim>
                {
                    new PermissionClaim { Type = "Permission", Name = "Administration Roles", Value = "administration-roles" },
                    new PermissionClaim { Type = "Permission", Name = "Administration Users", Value = "administration-users" },
                    new PermissionClaim { Type = "Permission", Name = "Control App Settings", Value = "app-settings-control" },
                    new PermissionClaim { Type = "Permission", Name = "Access Audit Log", Value = "audeting-access" },
                    new PermissionClaim { Type = "Permission", Name = "Access Error Log", Value = "error-log-access" },
                    new PermissionClaim { Type = "Permission", Name = "Control Push Notification", Value = "push-notification-control" },
                    new PermissionClaim { Type = "Permission", Name = "Control Reporting", Value = "reporting-control" },
                    new PermissionClaim { Type = "Permission", Name = "Control Indexes", Value = "indexes-control" },

                };

                DbContext.PermissionClaims.AddRange(permissions);
                DbContext.SaveChanges();
            }

            return Ok();
        }

    }
}
