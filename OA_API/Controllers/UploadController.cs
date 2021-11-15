using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OA.DataAccess;
using OA.Domin.RequestFeatures;
using OA.Domin.Requests;
using OA.Services.Upload;

namespace OA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UploadController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly UploadService uploadService;

        public UploadController(AppDbContext dbContext, UploadService uploadService)
        {
            this.dbContext = dbContext;
            this.uploadService = uploadService;
        }

        [HttpPost("UploadProfilePic")]
        public async Task<IActionResult> UploadProfilePic(ProfilePicRequest profilePicReq)
        {

            var result = await uploadService.UploadProfilePic(profilePicReq);

            if (result.HasErrors)
                return Ok(result);

            
            var user = dbContext.Users.Find(profilePicReq.userId);
            var oldPic = user.ProfilePic;

            //Save File Path In DB
            user.ProfilePic = result.Result;
            dbContext.Entry(user).State = EntityState.Modified;
            dbContext.SaveChanges();


            //Delete Old Pic
            if(!string.IsNullOrEmpty(oldPic))
                uploadService.DeleteProfilePic(oldPic);



            return Ok(result);

        }

    }
}
