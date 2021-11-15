using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using OA.Domin;
using OA.Domin.Reporting.TemplateReporting;
using OA.Domin.Resources;
using OA.WASM.Services;
using OA.WASM.Services.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.Reporting
{
    public partial class TextTemplateList : ComponentBase, IDisposable
    {

        [Inject]
        public IReportingService ReportingService { get; set; }

        [Inject]
        public HttpInterceptorService InterceptorService { get; set; }

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public IEnumerable<IndexData> ReportTextTemplates { get; set; }

        protected async override Task OnInitializedAsync()
        {
            InterceptorService.RegisterEvents();

            ReportTextTemplates = await ReportingService.GetReportTextTemplates();
        }

        public void Dispose()
        {
            InterceptorService.DisposeEvents();
        }

    }
}
