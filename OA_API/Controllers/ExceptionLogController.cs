using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.DataAccess;
using OA.Domin.Logging;

namespace OA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExceptionLogController : BaseController<ExceptionLog>
    {
        //private readonly AppDbContext Context;

        public ExceptionLogController(AppDbContext context) : base(context)
        {
            //this.Context = context;
        }

    }
}
