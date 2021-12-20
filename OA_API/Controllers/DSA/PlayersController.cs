using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.DataAccess;
using OA.Domin.DSA;
using OA.Domin.Responces;
using OA.Services.COM_ADM;
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
    public class PlayersController : BaseController<Player>
    {
        private readonly UploadService UploadService;
        public PlayersController(AppDbContext context, UploadService uploadService) : base(context)
        {
            UploadService = uploadService;
        }
      
  



        public async override Task<IActionResult> Create(Player player)
        {
            var result = new Response<Player> { Result = player };


            if (player.Person.Image != null)
            {

                var imageUploadResult = await UploadService.UploadFile(player.Person.Image, "StaticFiles/Images/SiteImages");
                if (imageUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = imageUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                player.Person.ImagePath = imageUploadResult.Result;
            }

            return await base.Create(player);
        }

        public async override Task<IActionResult> Update(Player player)
        {

            var result = new Response<Player> { Result = player };



            if (player.Person.Image != null && player.Person.Image.Data.Length != 0)
            {
                UploadService.DeleteUploadedFile(player.Person.ImagePath);
                var imageUploadResult = await UploadService.UploadFile(player.Person.Image, "StaticFiles/Images/SiteImages");
                if (imageUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = imageUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                player.Person.ImagePath = imageUploadResult.Result;
            }

            return await base.Update(player);
        }

        public async override Task<IActionResult> Delete(int id)
        {
            var person = Context.People.Find(id);

            UploadService.DeleteUploadedFile(person.ImagePath);

            return await base.Delete(id);

        }

    }
}
