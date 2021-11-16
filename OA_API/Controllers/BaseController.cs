using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using OA.DataAccess;
using OA.Domin;
using OA.Domin.DataFilter;
using OA.Domin.Paging;
using OA.Domin.Reflection;
using OA.Domin.RequestFeatures;
using OA.Domin.Requests;
using OA.Domin.Resources;
using OA.Domin.Responces;
using OA.Domin.Settings;
using OA.Services.Notifications;
using OA.Services.Reporting;
using OA.Services.Seeding;
using OA_API.ActionFilters;
using OA_API.LocalServices.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;
using System.Threading.Tasks;

namespace OA_API.Controllers
{
    public class BaseController<T> : ControllerBase where T : class, new()
    {
        protected readonly DbSet<T> DbSet;
        protected readonly AppDbContext Context;

        public BaseController(AppDbContext context)
        {          
            this.Context = context;
            this.DbSet = Context.Set<T>();
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get([FromQuery] RequestParameters pagingParameters)
        {
            //throw new Exception("TEST EXCEPTION");

            List<T> list = await DbSet.ToListAsync();

            var listFilter = (pagingParameters.FilterParams != null) ? EntityFilter<T>.FilteredData(pagingParameters.FilterParams, list, pagingParameters.Gather) : list;

            listFilter = listFilter.OrderByDescending(i => i.GetType().GetProperty("CreatedAt").GetValue(i));

            var resultList = PagedList<T>.ToPagedList(listFilter, pagingParameters.PageNumber, pagingParameters.PageSize);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(resultList.PagingData));

            return Ok(resultList);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(T entity)
        {
            DbSet.Add(entity);
            var c = await Context.SaveChangesAsync();

            var result = new Response<T>()
            {
                Result = entity,
                HasErrors = (c == 0)
            };
            return Ok(result);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Update(T entity)
        {
            //Context.Entry(entity).State = EntityState.Modified;
            Context.Update(entity);
            var c = await Context.SaveChangesAsync();

            var result = new Response<T>()
            {
                Result = entity,
                HasErrors = (c == 0)
            };
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity == null)
                return NotFound();

            DbSet.Remove(entity);
            await Context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("Export")]
        public virtual async Task<IActionResult> ExportReportAsync(ExportRequest exportRequest, [FromServices] ReportingService reportingService)
        {
            List<T> list = await DbSet.ToListAsync();

            var filterOptions = exportRequest.FilterOptions.FilterParams;
            var data = (filterOptions != null) ? EntityFilter<T>.FilteredData(filterOptions, list, exportRequest.FilterOptions.Gather) : list;

            var contentType = FileSettings.FileMemeTypes[exportRequest.ExportAs];

            var fileBytes = reportingService.ExportReport(data, exportRequest);

            return File(fileBytes, contentType, exportRequest.FileName, true);
        }

        [HttpGet("IndexGet")]
        [AllowAnonymous]
        public virtual async Task<IActionResult> IndexGet()
        {
            List<T> list = await DbSet.ToListAsync();

            var result = list.Select(item => new IndexData
            {
                Id = (item.GetType().GetProperty("Id").GetValue(item) != null) ? Convert.ToInt32(item.GetType().GetProperty("Id").GetValue(item)) : 0,
                Name = (item.GetType().GetProperty("Name").GetValue(item) != null) ? item.GetType().GetProperty("Name").GetValue(item).ToString() : "",
            });

            return Ok(result);
        }

#if DEBUG

        [HttpGet("Seed/{count}")]
        [AllowAnonymous]
        public IActionResult SeedTestData(int count)
        {

            for (int i = 0; i < count; i++)
            {

                var testEntity = ReflectionAccessor.FastActivator<T>.SeedCreate(i);

                DbSet.Add(testEntity);
            }

            Context.SaveChanges();

            return Ok();

        }

        #endif


    }
}
