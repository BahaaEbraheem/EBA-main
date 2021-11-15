using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.DataAccess;
using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA_API.Controllers.DSA
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "articles-control")]
    public class ArticleCategoriesController : BaseController<ArticleCategory>
    {
        public ArticleCategoriesController(AppDbContext context) : base(context)
        {

        }
    }
}
