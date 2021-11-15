using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using OA.Domin.DSA;
using OA.Domin.Resources;
using OA.WASM.Services;
using OA.WASM.Services.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.Attachments
{
    public partial class ItemAttachments : ComponentBase, IDisposable
    {

        [Parameter]
        public string Reference { get; set; }

        [Parameter]
        public string ReferenceId { get; set; }

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Inject]
        public AttachmentsServices AttachmentsService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public HttpInterceptorService InterceptorService { get; set; }

        public IEnumerable<Attachment> Attachments { get; set; }


        protected async override Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Reference) && !string.IsNullOrEmpty(ReferenceId))
            {
                if(int.TryParse(ReferenceId, out int refId)) 
                {
                    InterceptorService.RegisterEvents();

                    Attachments = await AttachmentsService.GetItemAttachments(Reference, refId);
                }               
            }
        }

        public void Dispose()
        {
            InterceptorService.DisposeEvents();
        }

    }
}
