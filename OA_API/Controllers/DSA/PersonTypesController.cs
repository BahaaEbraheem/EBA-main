using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.DataAccess;
using OA.Domin.AutoMapper;
using OA.Domin.DSA;
using OA.Domin.DSA.ViewModels;
using OA.Services.DSA.Interfaces;
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
    public class PersonTypesController : BaseController<PersonType>
    {
       
        public PersonTypesController(AppDbContext context) : base(context)
        {
           
        }


    }
}
