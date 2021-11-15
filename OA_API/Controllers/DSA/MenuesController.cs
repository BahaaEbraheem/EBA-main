using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.DataAccess;
using OA.Domin.DSA;
using OA.Domin.Responces;
using OA.Services.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA_API.Controllers.DSA
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "menues-control")]
    public class MenuesController : BaseController<Menue>
    {

        private readonly UploadService UploadService;
        public MenuesController(AppDbContext context, UploadService uploadService) : base(context) 
        {
            UploadService = uploadService;
        }

        public async override Task<IActionResult> Create(Menue menue)
        {
            var result = new Response<Menue> { Result = menue };

            if (menue.File != null)
            {
                var fileUploadResult = await UploadService.UploadFile(menue.File, "StaticFiles/SiteFiles");
                if (fileUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = fileUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                menue.FilePath = fileUploadResult.Result;
            }

            if (menue.Image != null)
            {

                var imageUploadResult = await UploadService.UploadFile(menue.Image, "StaticFiles/Images/SiteImages");
                if (imageUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = imageUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                menue.ImagePath = imageUploadResult.Result;
            }

            return await base.Create(menue);
        }

        public async override Task<IActionResult> Update(Menue menue)
        {

            var result = new Response<Menue> { Result = menue };

            if (menue.File != null && menue.File.Data.Length != 0)
            {
                UploadService.DeleteUploadedFile(menue.FilePath);
                var fileUploadResult = await UploadService.UploadFile(menue.File, "StaticFiles/SiteFiles");
                if (fileUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = fileUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                menue.FilePath = fileUploadResult.Result;
            }

            if (menue.Image != null && menue.Image.Data.Length != 0)
            {
                UploadService.DeleteUploadedFile(menue.ImagePath);
                var imageUploadResult = await UploadService.UploadFile(menue.Image, "StaticFiles/Images/SiteImages");
                if (imageUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = imageUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                menue.ImagePath = imageUploadResult.Result;
            }

            return await base.Update(menue);
        }

        public async override Task<IActionResult> Delete(int id)
        {
            var menue = Context.Menues.Find(id);

            UploadService.DeleteUploadedFile(menue.FilePath);

            UploadService.DeleteUploadedFile(menue.ImagePath);

            return await base.Delete(id);

        }

    }
}
