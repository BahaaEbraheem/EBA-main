using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OA.DataAccess;
using OA.Domin.Settings;

namespace OA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppSettingsController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public AppSettingsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("GetAppSettings")]
        public IActionResult GetAppSettings()
        {
            var list = dbContext.AppSettings.ToList();

            return Ok(list);
        }

        [Authorize]
        [HttpPost("SetAppSettings")]
        public IActionResult SetAppSettings(IEnumerable<AppSetting> appSettings)
        {            
            foreach(var appSetting in appSettings)
            {
                var currAppSetting = dbContext.AppSettings.Find(appSetting.Key);
                if (currAppSetting == null) continue;

                if (currAppSetting.Value == appSetting.Value) continue;

                currAppSetting.Value = appSetting.Value;
                dbContext.Entry(currAppSetting).State = EntityState.Modified;
                dbContext.SaveChanges();
            }

            var currAppSettings = dbContext.AppSettings.ToList();

            return Ok(currAppSettings);
        }

    }
}
