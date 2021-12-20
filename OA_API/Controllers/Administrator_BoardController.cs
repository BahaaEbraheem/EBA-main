//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using DocumentFormat.OpenXml.Office.CustomUI;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json;
//using OA.DataAccess;
//using OA.Domain.Requests;
//using OA.Domin.Administration;
//using OA.Domin.DataFilter;
//using OA.Domin.DSA.ViewModels;
//using OA.Domin.Paging;
//using OA.Domin.RequestFeatures;
//using OA.Domin.Requests;
//using OA.Domin.Responces;
//using OA.Services.Administration;
//using OA.Services.Administrator_Board;
//using OA_API.Extentions;

//namespace OA_API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    //[Authorize]
//    public class Administrator_BoardController : ControllerBase
//    {

//        private readonly IAdministrator_BoardService Administrator_BoardService;
//        private readonly AppDbContext dbContext;
//        private readonly UserManager<User> userManager;

//        public Administrator_BoardController(IAdministrator_BoardService administrator_Service,
//                                        AppDbContext dbContext,
//                                        UserManager<User> userManager)
//        {
//            this.Administrator_BoardService = administrator_Service;
//            this.dbContext = dbContext;
//            this.userManager = userManager;
//        }





//        [HttpGet("GetAllAdministrators")]
//        public IActionResult GetAllAdministrators()
//        {
//            var result = Administrator_BoardService.GetAllAdministrators();

//            return Ok(result);
//        }

//        [HttpPost("CreateCommission_Administrators")]
//        public IActionResult CreateCommission_Administrators(AdministrationBoardVM Commission_admini_VM)
//        {
//            var result = Administrator_BoardService.CreateCommission_Adm( Commission_admini_VM);

//            return Ok(result);
//        }

//    }
//}
