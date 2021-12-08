using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.DataAccess;
using OA.Domin.AutoMapper;
using OA.Domin.DSA;
using OA.Domin.DSA.ViewModels;
using OA.Domin.Responces;
using OA.Services.DSA;
using OA.Services.DSA.Interfaces;
using OA.Services.Upload;
using OA_API.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA_API.Controllers.DSA
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "people-control")]
    public class AdministrationBoardsController : BaseController<AdministrationBoard>
    {
        private readonly UploadService UploadService;
        public AdministrationBoardsController(AppDbContext context, UploadService uploadService, IAdministrationBoardService administrationboardService) : base(context)
        {
            UploadService = uploadService;
        }
       
  

        public async override Task<IActionResult> Create(AdministrationBoard administrationboard)
        {
            var result = new Response<AdministrationBoard> { Result = administrationboard };


            if (administrationboard.Person.Image != null)
            {

                var imageUploadResult = await UploadService.UploadFile(administrationboard.Person.Image, "StaticFiles/Images/SiteImages");
                if (imageUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = imageUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                administrationboard.Person.ImagePath = imageUploadResult.Result;
            }

            return await base.Create(administrationboard);
        }

        public async override Task<IActionResult> Update(AdministrationBoard administrationboard)
        {

            var result = new Response<AdministrationBoard> { Result = administrationboard };



            if (administrationboard.Person.Image != null && administrationboard.Person.Image.Data.Length != 0)
            {
                UploadService.DeleteUploadedFile(administrationboard.Person.ImagePath);
                var imageUploadResult = await UploadService.UploadFile(administrationboard.Person.Image, "StaticFiles/Images/SiteImages");
                if (imageUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = imageUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                administrationboard.Person.ImagePath = imageUploadResult.Result;
            }

            return await base.Update(administrationboard);
        }

        public async override Task<IActionResult> Delete(int id)
        {
            var person = Context.People.Find(id);

            UploadService.DeleteUploadedFile(person.ImagePath);

            return await base.Delete(id);

        }



    }
}
