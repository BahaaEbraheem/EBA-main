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
    [Authorize(Policy = "news-control")]
    public class NewsController : BaseController<New>
    {
        private readonly UploadService UploadService;
        public NewsController(AppDbContext context, UploadService uploadService) : base(context) 
        {
            UploadService = uploadService;
        }

        public async override Task<IActionResult> Create(New New1)
        {
            var result = new Response<New> { Result = New1 };

            if (New1.File != null)
            {
                var fileUploadResult = await UploadService.UploadFile(New1.File, "StaticFiles/SiteFiles");
                if (fileUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = fileUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                New1.FilePath = fileUploadResult.Result;
            }

            if (New1.Image != null)
            {
                var imageUploadResult = await UploadService.UploadFile(New1.Image, "StaticFiles/Images/SiteImages");
                if (imageUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = imageUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                New1.ImagePath = imageUploadResult.Result;
            }

            return await base.Create(New1);
        }

        public async override Task<IActionResult> Update(New New1)
        {
            var result = new Response<New> { Result = New1 };

            if (New1.File != null && New1.File.Data.Length != 0)
            {
                UploadService.DeleteUploadedFile(New1.FilePath);
                var fileUploadResult = await UploadService.UploadFile(New1.File, "StaticFiles/SiteFiles");
                if (fileUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = fileUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                New1.FilePath = fileUploadResult.Result;
            }

            if (New1.Image != null && New1.Image.Data.Length != 0)
            {
                UploadService.DeleteUploadedFile(New1.ImagePath);
                var imageUploadResult = await UploadService.UploadFile(New1.Image, "StaticFiles/Images/SiteImages");
                if (imageUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = imageUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                New1.ImagePath = imageUploadResult.Result;
            }

            return await base.Update(New1);
        }

        public async override Task<IActionResult> Delete(int id)
        {
            var New1 = Context.News.Find(id);

            UploadService.DeleteUploadedFile(New1.FilePath);

            UploadService.DeleteUploadedFile(New1.ImagePath);

            return await base.Delete(id);
        }

    }
}
