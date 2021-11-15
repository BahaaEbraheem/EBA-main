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
    public class EventCategoriesController : BaseController<EventCategory>
    {
        private readonly UploadService UploadService;
        public EventCategoriesController(AppDbContext context, UploadService uploadService) : base(context)
        {
            UploadService = uploadService;
        }


        public async override Task<IActionResult> Create(EventCategory eventCategory)
        {
            var result = new Response<EventCategory> { Result = eventCategory };

            var imageUploadResult = await UploadService.UploadFile(eventCategory.Image, "StaticFiles/Images/SiteImages");
            if (imageUploadResult.HasErrors)
            {
                result.HasErrors = true;
                result.ValidationErrors = imageUploadResult.ValidationErrors;
                return await Task.FromResult(Ok(result));
            }
            eventCategory.ImagePath = imageUploadResult.Result;

            return await base.Create(eventCategory);
        }

        public async override Task<IActionResult> Update(EventCategory eventCategory)
        {
            var result = new Response<EventCategory> { Result = eventCategory };

            if (eventCategory.Image != null && eventCategory.Image.Data.Length != 0)
            {
                UploadService.DeleteUploadedFile(eventCategory.ImagePath);

                var imageUploadResult = await UploadService.UploadFile(eventCategory.Image, "StaticFiles/Images/SiteImages");
                if (imageUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = imageUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                eventCategory.ImagePath = imageUploadResult.Result;
            }

            return await base.Update(eventCategory);
        }

        public async override Task<IActionResult> Delete(int id)
        {
            var existedEventCategory = Context.EventCategories.Find(id);
            UploadService.DeleteUploadedFile(existedEventCategory.ImagePath);

            return await base.Delete(id);
        }

    }
}
