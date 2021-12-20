using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.DataAccess;
using OA.Domin.DSA;
using OA.Domin.Responces;
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
    public class CommissionsController : BaseController<Commission>
    {

        public CommissionsController(AppDbContext context) : base(context)
        {

        }
        public async override Task<IActionResult> Create(Commission commission)
        {
            var userId = HttpContext.User.GetUserId();
            var result = new Response<Commission> { Result = commission };
           var Comm_Mem= new CommissionMember(){CommissionId=commission.Id,Commission=commission,AdministrationBoardId=null,DecisionId=null,CreatedBy=userId,CreatedAt=DateTime.Now,StartDate=DateTime.Now };
            commission.CommissionMembers.Add(Comm_Mem);

            return await base.Create(commission);
        }
    }
}
