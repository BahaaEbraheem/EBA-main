using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using OA.Domin.Attributes;
using OA.Domin.Reflection;
using OA.Domin.Reporting;
using OA.Domin.Resources;
using OA.WASM.Services;
using OA.WASM.Services.Auth;
using OA.WASM.Services.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.Reporting
{
    public partial class Reporting : ComponentBase
    {
        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Inject]
        public IReportingService ReportingService { get; set; }

        [Inject]
        public HttpInterceptorService InterceptorService { get; set; }

        [Inject]
        public IJSRuntime JSRT { get; set; }

        public IEnumerable<ReportableTable> ReportableTables { get; set; } = new List<ReportableTable>();

        public ReportableTable ReportableTable { get; set; } = new ReportableTable();

        public Dictionary<string, string> ReportableTypes { get; set; } = new Dictionary<string, string>();

        public ReportTemplate ReportTemplate { get; set; } = new ReportTemplate();

        public ReportTemplate SelectedTemplate { get; set; } = null;

        public ReportableTable SelectedTable { get; set; } = null;

        public TemplateEditor TemplateEditor { get; set; }

        protected async override Task OnInitializedAsync()
        {
            InterceptorService.RegisterEvents();

            await GetReportableTables();

            GetReortableTypes();
        }

        public async Task GetReportableTables()
        {
            ReportableTables = await ReportingService.GetReportableTables();

            if (SelectedTable != null) 
                SelectedTable = ReportableTables.Where(t => t.Id == SelectedTable.Id).FirstOrDefault();
            if (SelectedTemplate != null)
            {
                SelectedTemplate = SelectedTable.ReportTemplates.Where(t => t.Id == SelectedTemplate.Id).FirstOrDefault();

                //If Selected Template Get Delted
                if (SelectedTemplate != null) 
                    SelectedTemplate.ReportableTable = SelectedTable;
                else 
                    SelectedTemplate = null;
            }
            
            StateHasChanged();
        }

        public void GetReortableTypes()
        {
            ReportableTypes = new Dictionary<string, string>();
            var allReportableTypes = ReflectionAccessor.GetEntityTypes();
            foreach(var reportableType in allReportableTypes)
            {
                var exist = false;
                foreach (var added in ReportableTables)
                    if (reportableType.Key == added.TypeName)
                        exist = true;
                if (!exist)
                    ReportableTypes.Add(reportableType.Key, reportableType.Value);
            }
        }

        public async Task CreateReportableTable()
        {
            ReportableTable.Name = ReportableTypes[ReportableTable.TypeName];

            await ReportingService.CreateReportableTable(ReportableTable);

            await GetReportableTables();
            GetReortableTypes();

            StateHasChanged();

            await JSRT.InvokeVoidAsync("Toast", Localizer["Changes Saved Successfully"].Value);
            
        }

        public async Task CreateReportTemplate()
        {
            ReportTemplate.FieldsOrder = GetDefaultFieldsOrder();
            ReportTemplate.ReportableTableId = SelectedTable.Id;

            if (ReportTemplate.FieldsOrder == "") return;

            
            await ReportingService.CreateReportTemplate(ReportTemplate);

            await GetReportableTables();
            StateHasChanged();

            await JSRT.InvokeVoidAsync("Toast", Localizer["Changes Saved Successfully"].Value);
        }

        public async Task TemplateEdited()
        {
            await GetReportableTables();
        }

        public string GetDefaultFieldsOrder()
        {
            var type = ReflectionAccessor.GetType(SelectedTable.TypeName);
            if (type == null) return "";

            var fieldsList = AttributeAccessor.GetPropsWithNames(type, new List<string>() { SelectedTable.TypeName });
            var defaultTemplate = "";
            foreach(var field in fieldsList)         
                defaultTemplate += $"{field.Key}:{field.Value},";

            defaultTemplate = defaultTemplate.Remove(defaultTemplate.Length - 1, 1);
            return defaultTemplate;
        }

        public void SelectTemplate(ReportTemplate template)
        {
            SelectedTemplate = null;

            SelectedTemplate = template;
            SelectedTemplate.ReportableTable = SelectedTable;

            StateHasChanged();

            //if(TemplateEditor != null) TemplateEditor.InitFields();
        }

        public void SelectTable(ReportableTable reportableTable)
        {
            SelectedTable = reportableTable;
            SelectedTemplate = null;

            StateHasChanged();
        }

    }
}
