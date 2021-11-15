using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OA.DataAccess;
using OA.Domin.Reporting;
using OA.Domin.Reporting.TemplateReporting;
using OA.Services.Notifications;
using OA.Services.Reporting;

namespace OA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "reporting-control")]
    public class ReportingController : ControllerBase
    {
        private readonly AppDbContext Context;
        private readonly ReportingService ReportingService;

        public ReportingController(AppDbContext context, ReportingService reportingService)
        {
            this.Context = context;
            ReportingService = reportingService;
        }

        [HttpGet("GetReportableTables")]
        public async Task<IActionResult> GetReportableTables()
        {

            return Ok(await Context.ReportableTables.ToListAsync());
        }

        [HttpPost("CreateReportableTable")]
        public async Task<IActionResult> CreateReportableTable(ReportableTable reportableTable)
        {
            Context.ReportableTables.Add(reportableTable);
            await Context.SaveChangesAsync();

            return Created("Reporting/CreateReportableTable", reportableTable);

        }

        [HttpPost("CreateReportTemplate")]
        public async Task<IActionResult> CreateReportTemplate(ReportTemplate reportTemplate)
        {
            Context.ReportTemplates.Add(reportTemplate);
            await Context.SaveChangesAsync();

            return Created("Reporting/CreateReportTemplate", reportTemplate);
        }

        [HttpPost("SaveReportHeader")]
        public async Task<IActionResult> SaveReportHeader(ReportHeader reportHeader)
        {
            if (reportHeader.Id == 0)
                Context.ReportHeaders.Add(reportHeader);
            else            
                Context.Entry(reportHeader).State = EntityState.Modified;

            await Context.SaveChangesAsync();

            return Ok(reportHeader);
            
        }

        [HttpGet("GetReportTemplate/{id}")]
        public async Task<IActionResult> GetReportTemplate(int id)
        {
            return Ok(await Context.ReportTemplates.FindAsync(id));
        }

        [HttpDelete("DeleteReportHeader/{id}")]
        public async Task<IActionResult> DeleteReportHeader(int id)
        {
            var header = Context.ReportHeaders.Find(id);
            Context.ReportHeaders.Remove(header);
            await Context.SaveChangesAsync();

            return Ok(header);
        }

        [HttpPost("SaveReportFields")]
        public async Task<IActionResult> SaveReportFields(ReportTemplate reportTemplate)
        {
            Context.Entry(reportTemplate).State = EntityState.Modified;
            await Context.SaveChangesAsync();

            return Ok(reportTemplate);
        }

        [HttpDelete("DeleteReportTemplate/{id}")]
        public async Task<IActionResult> DeleteReportTemplate(int id)
        {
            var template = Context.ReportTemplates.Find(id);
            Context.ReportTemplates.Remove(template);
            await Context.SaveChangesAsync();

            return Ok(template);
        }

        [HttpGet("ChangeTemplateState/{id}")]
        public async Task<IActionResult> ChangeTemplateState(int id)
        {
            var template = Context.ReportTemplates.Find(id);
            if (template == null)
                return BadRequest();

            var transaction = Context.Database.BeginTransaction();
            try
            {
                //set template staus to active
                template.Status = true;
                Context.Entry(template).State = EntityState.Modified;
                await Context.SaveChangesAsync();

                //change all other templates (For Current Table) status to passive
                var otherTemplates = Context.ReportTemplates.Where(t => t.Status && t.Id != template.Id && t.ReportableTableId == template.ReportableTableId).ToList(); 
                //ToList() Call Close The Context Data Readed and Convert Result From IQueriable To IEnumrable(IList)
                foreach(var otherTemplate in otherTemplates)
                {
                    otherTemplate.Status = false;
                    Context.Entry(otherTemplate).State = EntityState.Modified;
                    await Context.SaveChangesAsync();
                }

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }


            return Ok();
        }

        [HttpGet("GetReportTextTemplates")]
        public IActionResult GetReportTextTemplates()
        {
            var result = ReportingService.GetReportTextTemplates();

            return Ok(result);
        }


        [HttpGet("GetReportTextTemplate/{id}")]
        public IActionResult GetReportTextTemplate(int id)
        {
            var result = ReportingService.GetReportTextTemplate(id);

            return Ok(result);
        }

        [HttpPost("SaveReportTemplate")]
        public IActionResult SaveReportTemplate(ReportTextTemplate reportTextTemplate)
        {
            ReportingService.SaveReportTextTemplate(reportTextTemplate);

            return Ok();
        }

    }
}
