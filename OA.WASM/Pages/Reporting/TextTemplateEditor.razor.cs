using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using OA.Domin.Reporting.TemplateReporting;
using OA.Domin.Resources;
using OA.WASM.Services;
using OA.WASM.Services.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace OA.WASM.Pages.Reporting
{
    public partial class TextTemplateEditor : ComponentBase, IDisposable
    {
        [Inject]
        public IReportingService ReportingService { get; set; }

        [Inject]
        public HttpInterceptorService InterceptorService { get; set; }

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IJSRuntime JSRT { get; set; }


        public ReportTextTemplate ReportTextTemplate { get; set; } = new ReportTextTemplate();

        protected async override Task OnInitializedAsync()
        {
            InterceptorService.RegisterEvents();

            var reportTextTemplateId = Convert.ToInt32(Id);

            ReportTextTemplate = await ReportingService.GetReportTextTemplate(reportTextTemplateId);

        }

        public async Task SaveTemplate()
        {
            await ReportingService.SaveReportTemplate(ReportTextTemplate);

            await JSRT.InvokeVoidAsync("Toast", Localizer["Changes Saved Successfully"].Value);
        }


        public void Dispose()
        {
            InterceptorService.DisposeEvents();
        }

    }
}
