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
    public class PageTranslationsController : BaseController<PageTranslation>
    {

        private readonly UploadService UploadService;
        public PageTranslationsController(AppDbContext context, UploadService uploadService) : base(context)
        {
            UploadService = uploadService;
        }

        public async override Task<IActionResult> Create(PageTranslation pageTranslation)
        {
            var result = new Response<PageTranslation> { Result = pageTranslation };

            var fileUploadResult = await UploadService.UploadFile(pageTranslation.File, "StaticFiles/SiteFiles");
            if (fileUploadResult.HasErrors)
            {
                result.HasErrors = true;
                result.ValidationErrors = fileUploadResult.ValidationErrors;
                return await Task.FromResult(Ok(result));
            }
            pageTranslation.FilePath = fileUploadResult.Result;

            return await base.Create(pageTranslation);
        }

        public async override Task<IActionResult> Update(PageTranslation pageTranslation)
        {

            var result = new Response<PageTranslation> { Result = pageTranslation };

            if (pageTranslation.File != null && pageTranslation.File.Data.Length != 0)
            {
                UploadService.DeleteUploadedFile(pageTranslation.FilePath);
                var fileUploadResult = await UploadService.UploadFile(pageTranslation.File, "StaticFiles/SiteFiles");
                if (fileUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = fileUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                pageTranslation.FilePath = fileUploadResult.Result;
            }

            return await base.Update(pageTranslation);
        }

        public async override Task<IActionResult> Delete(int id)
        {

            var pageTranslation = Context.PageTranslations.Find(id);

            UploadService.DeleteUploadedFile(pageTranslation.FilePath);

            return await base.Delete(id);
        }

    }
}
