using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office.CustomUI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OA.DataAccess;
using OA.Domain.Requests;
using OA.Domin.Administration;
using OA.Domin.DataFilter;
using OA.Domin.Paging;
using OA.Domin.RequestFeatures;
using OA.Domin.Requests;
using OA.Domin.Responces;
using OA.Services.Administration;
using OA_API.Extentions;

namespace OA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdministrationController : ControllerBase
    {

        private readonly IAdministrationService AdministrationService;
        private readonly AppDbContext dbContext;
        private readonly UserManager<User> userManager;

        public AdministrationController(IAdministrationService administrationService,
                                        AppDbContext dbContext,
                                        UserManager<User> userManager)
        {
            this.AdministrationService = administrationService;
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        #region "Users Managmant Routs"

        [HttpGet("GetAllUsers")]
        [Authorize(Policy = "administration-users")]
        public async Task<IActionResult> GetAllUsers([FromQuery] RequestParameters pagingParameters)
        {
            var list = await AdministrationService.GetAllUsers();

            var listFilter = (pagingParameters.FilterParams != null) ? EntityFilter<CustomUser>.FilteredData(pagingParameters.FilterParams, list, pagingParameters.Gather) : list;

            //listFilter = listFilter.OrderByDescending(i => i.GetType().GetProperty("CreatedAt").GetValue(i));

            var resultList = PagedList<CustomUser>.ToPagedList(listFilter, pagingParameters.PageNumber, pagingParameters.PageSize);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(resultList.PagingData));

            return Ok(resultList);
        }

        [HttpGet("IndexGetAllUser")]
        public async Task<IActionResult> IndexGetAllUser()
        {
            var list = await AdministrationService.GetAllUsers();

            return Ok(list);
        }

        [HttpPost("CreateUser")]
        [Authorize(Policy = "administration-users")]
        public async Task<IActionResult> CreateUser(CustomUser user)
        {
            var result = await AdministrationService.AddUserAsync(user);

            return Ok(result);
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(CustomUser user)
        {
            var userId = HttpContext.User.GetUserId();
            if (!HttpContext.User.IsAdmin())
                user.Id = userId;

            var result = AdministrationService.UpdateUser(user);
            return Ok(result);
        }

        [HttpDelete("DeleteUser/{Id}")]
        [Authorize(Policy = "administration-users")]
        public IActionResult DeleteUser(string Id)
        {
            AdministrationService.DeleteUser(Id);
            return Ok();
        }

        [HttpGet("GetUser/{id}")]
        public IActionResult GetUser(string id)
        {
            var userId = HttpContext.User.GetUserId();
            var isAdmin = HttpContext.User.IsAdmin();

            if (!isAdmin && userId != id)
                return BadRequest();

            var result = AdministrationService.GetUserById(id);
            return Ok(result);
        }



        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest resetPassword)
        {
            var userId = HttpContext.User.GetUserId();
            if (!HttpContext.User.IsAdmin())
                resetPassword.Id = userId;

            var result = await AdministrationService.ResetPassword(resetPassword);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("GetVerificationQuestions")]
        public IActionResult GetUserVerificationQuestions()
        {
            var result = AdministrationService.GetVerificationQuestions();

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("GetUserVerificationQuestions/{email}")]
        public IActionResult GetUserVerificationQuestions(string email)
        {
            var result = AdministrationService.GetUserVerificationQuestions(email);
            return Ok(result);
        }

        [HttpPost("AddUserVerificationAnswer")]
        public IActionResult AddUserVerificationAnswer(IEnumerable<UserVerificationAnswerCreateRequest> userVerificationAnswers)
        {
            var userId = HttpContext.User.GetUserId();

            AdministrationService.AddUserVerificationAnswers(userVerificationAnswers, userId);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("ExternalResetPassword")]
        public async Task<IActionResult> ExternalResetPassword(ExternalResetPasswordRequest externalResetPassword)
        {
            var result = await AdministrationService.ExternalResetPassword(externalResetPassword);

            return Ok(result);
        }

        [HttpGet("GetUnProcessedSignupRequests")]
        public IActionResult GetUnProcessedSignupRequests()
        {
            var result = AdministrationService.GetUnProcessedSignupRequests();

            return Ok(result);
        }

        [HttpPost("ChangeSignUpRequestState")]
        public IActionResult ChangeSignUpRequestState(SignupRequest request)
        {
            var result = AdministrationService.ChangeSignUpRequestState(request);

            return Ok(result);
        }

        #endregion

        #region "Roles Managment Routs"

        [HttpGet("GetAllRoles")]
        public IActionResult GetAllRoles()
        {
            var result = AdministrationService.GetAllRoles();

            return Ok(result);
        }        

        [HttpGet("GetRole/{roleId}")]
        public IActionResult GetRole(string roleId)
        {
            var result = AdministrationService.GetRole(roleId);

            return Ok(result);
        }

        [HttpGet("GetAllPermissions")]
        public IActionResult GetAllPermissions()
        {
            var result = AdministrationService.GetPermissionClaims();

            return Ok(result);
        }

        [HttpPost("AddRole")]
        public IActionResult CreateRole(CustomRole role)
        {
            var result = AdministrationService.CreateRole(role);

            return Ok(result);
        }

        [HttpPut("UpdateRole")]
        public IActionResult UpdateRole(CustomRole role)
        {
            var result = AdministrationService.UpdateRole(role);

            return Ok(result);
        }

        [HttpDelete("DeleteRole/{roleId}")]
        public IActionResult DeleteRole(string roleId)
        {
            AdministrationService.DeleteRole(roleId);

            return Ok();
        }


        #endregion

    }
}
