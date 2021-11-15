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
    [Authorize(Policy = "events-control")]
    public class EventsController : BaseController<Event>
    {
        private readonly UploadService UploadService;
        public EventsController(AppDbContext context, UploadService uploadService) : base(context) 
        {
            UploadService = uploadService;
        }

        public async override Task<IActionResult> Create(Event event1)
        {
            var result = new Response<Event> { Result = event1 };

            if (event1.File != null)
            {
                var fileUploadResult = await UploadService.UploadFile(event1.File, "StaticFiles/SiteFiles");
                if (fileUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = fileUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                event1.FilePath = fileUploadResult.Result;
            }

            if (event1.Image != null)
            {
                var imageUploadResult = await UploadService.UploadFile(event1.Image, "StaticFiles/Images/SiteImages");
                if (imageUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = imageUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                event1.ImagePath = imageUploadResult.Result;
            }

            return await base.Create(event1);
        }

        public async override Task<IActionResult> Update(Event event1)
        {
            var result = new Response<Event> { Result = event1 };

            if (event1.File != null && event1.File.Data.Length != 0)
            {
                UploadService.DeleteUploadedFile(event1.FilePath);
                var fileUploadResult = await UploadService.UploadFile(event1.File, "StaticFiles/SiteFiles");
                if (fileUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = fileUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                event1.FilePath = fileUploadResult.Result;
            }

            if (event1.Image != null && event1.Image.Data.Length != 0)
            {
                UploadService.DeleteUploadedFile(event1.ImagePath);
                var imageUploadResult = await UploadService.UploadFile(event1.Image, "StaticFiles/Images/SiteImages");
                if (imageUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = imageUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                event1.ImagePath = imageUploadResult.Result;
            }

            return await base.Update(event1);
        }

        public async override Task<IActionResult> Delete(int id)
        {
            var event1 = Context.Events.Find(id);

            UploadService.DeleteUploadedFile(event1.FilePath);

            UploadService.DeleteUploadedFile(event1.ImagePath);

            return await base.Delete(id);
        }

    }
}
