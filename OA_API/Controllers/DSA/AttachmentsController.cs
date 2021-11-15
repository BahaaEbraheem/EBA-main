using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.DataAccess;
using OA.Domin.DSA;
using OA.Domin.Responces;
using OA.Services.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA_API.Controllers.DSA
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "attachments-control")]
    public class AttachmentsController : BaseController<Attachment>
    {

        private readonly UploadService UploadService;
        public AttachmentsController(AppDbContext context, UploadService uploadService) : base(context)
        {
            UploadService = uploadService;
        }

        public async override Task<IActionResult> Create(Attachment Attachment)
        {
            var result = new Response<Attachment> { Result = Attachment };

            var fileUploadResult = await UploadService.UploadFile(Attachment.File, "StaticFiles/SiteFiles/Attachments");
            if (fileUploadResult.HasErrors)
            {
                result.HasErrors = true;
                result.ValidationErrors = fileUploadResult.ValidationErrors;
                return await Task.FromResult(Ok(result));
            }
            Attachment.Path = fileUploadResult.Result;
            Attachment.Extention = Attachment.File?.FileType;

            return await base.Create(Attachment);
        }

        public async override Task<IActionResult> Update(Attachment Attachment)
        {
            var result = new Response<Attachment> { Result = Attachment };

            if (Attachment.File != null && Attachment.File.Data.Length != 0)
            {
                UploadService.DeleteUploadedFile(Attachment.Path);
                var fileUploadResult = await UploadService.UploadFile(Attachment.File, "StaticFiles/SiteFiles/Attachments");
                if (fileUploadResult.HasErrors)
                {
                    result.HasErrors = true;
                    result.ValidationErrors = fileUploadResult.ValidationErrors;
                    return await Task.FromResult(Ok(result));
                }
                Attachment.Path = fileUploadResult.Result;
                Attachment.Extention = Attachment.File?.FileType;
            }

            return await base.Update(Attachment);
        }

        public async override Task<IActionResult> Delete(int id)
        {
            var Attachment = Context.Attachments.Find(id);

            UploadService.DeleteUploadedFile(Attachment.Path);

            return await base.Delete(id);
        }

        [HttpGet("GetItemAttachments/{refName}/{refId}")]
        public IActionResult GetItemAttachments(string refName, int refId)
        {
            var attachments = Context.Attachments.Where(a => a.Reference == refName && a.ReferenceId == refId).ToList();

            return Ok(attachments);
        }

    }
}
