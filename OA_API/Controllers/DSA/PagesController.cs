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
    [Authorize(Policy = "pages-control")]
    public class PagesController : BaseController<Page>
    {

        private readonly UploadService UploadService;
        public PagesController(AppDbContext context, UploadService uploadService) : base(context)
        {
            UploadService = uploadService;
        }

        public async override Task<IActionResult> Create(Page page)
        {
            var result = new Response<Page> { Result = page };

            if (page.Image != null)
            {

                var imageUploadResult = await UploadService.UploadFile(page.Image, "StaticFiles/Images/SiteImages");
                if (imageUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = imageUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                page.ImagePath = imageUploadResult.Result;
            }

            return await base.Create(page);
        }

        public async override Task<IActionResult> Update(Page page)
        {
            var result = new Response<Page> { Result = page };

            if (page.Image != null && page.Image.Data.Length != 0)
            {
                UploadService.DeleteUploadedFile(page.ImagePath);
                var fileUploadResult = await UploadService.UploadFile(page.Image, "StaticFiles/Images/SiteImages");
                if (fileUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = fileUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                page.ImagePath = fileUploadResult.Result;
            }

            return await base.Update(page);
        }

        public async override Task<IActionResult> Delete(int id)
        {
            var page = Context.Pages.Find(id);

            UploadService.DeleteUploadedFile(page.ImagePath);

            return await base.Delete(id);
        }

    }
}
