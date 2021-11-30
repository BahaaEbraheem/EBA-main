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
    [Authorize(Policy = "people-control")]
    public class PeopleController : BaseController<Person>
    {

        private readonly UploadService UploadService;
        public PeopleController(AppDbContext context, UploadService uploadService) : base(context)
        {
            UploadService = uploadService;
        }

        public async override Task<IActionResult> Create(Person person)
        {
            var result = new Response<Person> { Result = person };
          

            if (person.Image != null)
            {

                var imageUploadResult = await UploadService.UploadFile(person.Image, "StaticFiles/Images/SiteImages");
                if (imageUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = imageUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                person.ImagePath = imageUploadResult.Result;
            }

            return await base.Create(person);
        }

        public async override Task<IActionResult> Update(Person person)
        {

            var result = new Response<Person> { Result = person };



            if (person.Image != null && person.Image.Data.Length != 0)
            {
                UploadService.DeleteUploadedFile(person.ImagePath);
                var imageUploadResult = await UploadService.UploadFile(person.Image, "StaticFiles/Images/SiteImages");
                if (imageUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = imageUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                person.ImagePath = imageUploadResult.Result;
            }

            return await base.Update(person);
        }

        public async override Task<IActionResult> Delete(int id)
        {
            var person = Context.People.Find(id);

            UploadService.DeleteUploadedFile(person.ImagePath);

            return await base.Delete(id);

        }

    }
}
