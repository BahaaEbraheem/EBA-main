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
    [Authorize(Policy = "blocks-control")]
    public class BlocksController : BaseController<Block>
    {
        private readonly UploadService UploadService;
        public BlocksController(AppDbContext context, UploadService uploadService) : base(context)
        {
            UploadService = uploadService;
        }

        public async override Task<IActionResult> Create(Block block)
        {
            var result = new Response<Block>{ Result = block};

            if (block.File != null)
            {
                var fileUploadResult = await UploadService.UploadFile(block.File, "StaticFiles/SiteFiles");
                if (fileUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = fileUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                block.FilePath = fileUploadResult.Result;
            }

            if (block.Image != null)
            {
                var imageUploadResult = await UploadService.UploadFile(block.Image, "StaticFiles/Images/SiteImages");
                if (imageUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = imageUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                block.ImagePath = imageUploadResult.Result;
            }
            
            return await base.Create(block);
        }

        public async override Task<IActionResult> Update(Block block)
        {
            var result = new Response<Block> { Result = block };

            if (block.File != null && block.File.Data.Length != 0)
            {
                UploadService.DeleteUploadedFile(block.FilePath);

                var fileUploadResult = await UploadService.UploadFile(block.File, "StaticFiles/SiteFiles");
                if (fileUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = fileUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                block.FilePath = fileUploadResult.Result;
            }

            if (block.Image != null && block.Image.Data.Length != 0)
            {
                UploadService.DeleteUploadedFile(block.ImagePath);

                var imageUploadResult = await UploadService.UploadFile(block.Image, "StaticFiles/Images/SiteImages");
                if (imageUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = imageUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                block.ImagePath = imageUploadResult.Result;
            }

            return await base.Update(block);
        }

        public async override Task<IActionResult> Delete(int id)
        {
            var block = Context.Blocks.Find(id);

            UploadService.DeleteUploadedFile(block.FilePath);

            UploadService.DeleteUploadedFile(block.ImagePath);

            return await base.Delete(id);
        }


    }
}
