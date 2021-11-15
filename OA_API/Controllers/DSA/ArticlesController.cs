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
    [Authorize(Policy = "articles-control")]
    public class ArticlesController : BaseController<Article>
    {
        private readonly UploadService UploadService;
        public ArticlesController(AppDbContext context, UploadService uploadService) : base(context)
        {
            UploadService = uploadService;
        }

        public async override Task<IActionResult> Create(Article Article)
        {
            var result = new Response<Article> { Result = Article };

            if (Article.File != null && Article.File.Data.Length != 0)
            {
                var fileUploadResult = await UploadService.UploadFile(Article.File, "StaticFiles/SiteFiles");
                if (fileUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = fileUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                Article.FilePath = fileUploadResult.Result;
            }

            if (Article.Image != null && Article.Image.Data.Length != 0)
            {
                var imageUploadResult = await UploadService.UploadFile(Article.Image, "StaticFiles/Images/SiteImages");
                if (imageUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = imageUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                Article.ImagePath = imageUploadResult.Result;
            }


            return await base.Create(Article);
        }

        public async override Task<IActionResult> Update(Article Article)
        {
            var result = new Response<Article> { Result = Article };

            if (Article.File != null && Article.File.Data.Length != 0)
            {
                if(!string.IsNullOrEmpty(Article.FilePath))
                    UploadService.DeleteUploadedFile(Article.FilePath);

                var fileUploadResult = await UploadService.UploadFile(Article.File, "StaticFiles/SiteFiles");
                if (fileUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = fileUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                Article.FilePath = fileUploadResult.Result;
            }

            if (Article.Image != null && Article.Image.Data.Length != 0)
            {
                if(!string.IsNullOrEmpty(Article.ImagePath))
                    UploadService.DeleteUploadedFile(Article.ImagePath);

                var imageUploadResult = await UploadService.UploadFile(Article.Image, "StaticFiles/Images/SiteImages");
                if (imageUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = imageUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                Article.ImagePath = imageUploadResult.Result;
            }

            return await base.Update(Article);
        }

        public async override Task<IActionResult> Delete(int id)
        {
            var Article = Context.Articles.Find(id);

            UploadService.DeleteUploadedFile(Article.FilePath);

            UploadService.DeleteUploadedFile(Article.ImagePath);

            return await base.Delete(id);
        }

    }
}
