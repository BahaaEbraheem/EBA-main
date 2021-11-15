using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using OA.DataAccess;
using OA.Domin.DataFilter;
using OA.Domin.Paging;
using OA.Domin.Reflection;
using OA.Domin.RequestFeatures;
using OA.Domin.Requests;
using OA.Domin.Settings;
using OA.Services.Caching;
using OA.Services.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace OA_API.Controllers
{
    public class BaseCachedController<T> : ControllerBase where T : class, new()
    {

        protected readonly DbSet<T> DbSet;
        protected readonly AppDbContext Context;
        protected readonly IMemoryCache Cache;

        public BaseCachedController(AppDbContext context, ULMemoryCacheService uLMCache)
        {
            this.Context = context;
            this.DbSet = Context.Set<T>();
            this.Cache = uLMCache.Cache;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestParameters pagingParameters)
        {
            //throw new Exception("TEST EXCEPTION");

            List<T> cachedList = new List<T>();
            var cacheKeyName = $"{typeof(T).Name}_List";

            if(!Cache.TryGetValue(cacheKeyName, out cachedList))
            {
                var DeepList = DbSet.Include(l => l.GetType().GetProperty("City")).ToList(); 
                cachedList = await DbSet.ToListAsync();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                // Keep in cache for this time, reset time if accessed.
                .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                // Keep in cache Maximum Time
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(20));

                Cache.Set(cacheKeyName, cachedList, cacheEntryOptions);
            }

            //List<T> list = await DbSet.ToListAsync();

            var listFilter = (pagingParameters.FilterParams != null) ? EntityFilter<T>.FilteredData(pagingParameters.FilterParams, cachedList, pagingParameters.Gather) : cachedList;

            listFilter = listFilter.OrderByDescending(i => i.GetType().GetProperty("CreatedAt").GetValue(i));

            var resultList = PagedList<T>.ToPagedList(listFilter, pagingParameters.PageNumber, pagingParameters.PageSize);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(resultList.PagingData));

            return Ok(resultList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create(T entity)
        {
            DbSet.Add(entity);
            await Context.SaveChangesAsync();

            return Created(nameof(T), entity);
        }

        [HttpPut]
        public async Task<IActionResult> Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity == null)
                return NotFound();

            DbSet.Remove(entity);
            await Context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("Export")]
        public async Task<IActionResult> ExportReportAsync(ExportRequest exportRequest, [FromServices] ReportingService reportingService)
        {
            List<T> list = await DbSet.ToListAsync();

            var filterOptions = exportRequest.FilterOptions.FilterParams;
            var data = (filterOptions != null) ? EntityFilter<T>.FilteredData(filterOptions, list, exportRequest.FilterOptions.Gather) : list;

            var contentType = FileSettings.FileMemeTypes[exportRequest.ExportAs];

            var fileBytes = reportingService.ExportReport(data, exportRequest);

            return File(fileBytes, contentType, exportRequest.FileName, true);
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
