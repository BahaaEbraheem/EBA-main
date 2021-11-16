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
    public class NewCategoriesController : BaseController<NewCategory>
    {
        private readonly UploadService UploadService;
        public NewCategoriesController(AppDbContext context, UploadService uploadService) : base(context)
        {
            UploadService = uploadService;
        }


        public async override Task<IActionResult> Create(NewCategory NewCategory)
        {
            var result = new Response<NewCategory> { Result = NewCategory };

            var imageUploadResult = await UploadService.UploadFile(NewCategory.Image, "StaticFiles/Images/SiteImages");
            if (imageUploadResult.HasErrors)
            {
                result.HasErrors = true;
                result.ValidationErrors = imageUploadResult.ValidationErrors;
                return await Task.FromResult(Ok(result));
            }
            NewCategory.ImagePath = imageUploadResult.Result;

            return await base.Create(NewCategory);
        }

        public async override Task<IActionResult> Update(NewCategory NewCategory)
        {
            var result = new Response<NewCategory> { Result = NewCategory };

            if (NewCategory.Image != null && NewCategory.Image.Data.Length != 0)
            {
                UploadService.DeleteUploadedFile(NewCategory.ImagePath);

                var imageUploadResult = await UploadService.UploadFile(NewCategory.Image, "StaticFiles/Images/SiteImages");
                if (imageUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = imageUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                NewCategory.ImagePath = imageUploadResult.Result;
            }

            return await base.Update(NewCategory);
        }

        public async override Task<IActionResult> Delete(int id)
        {
            var existedNewCategory = Context.NewCategories.Find(id);
            UploadService.DeleteUploadedFile(existedNewCategory.ImagePath);

            return await base.Delete(id);
        }

    }
}
