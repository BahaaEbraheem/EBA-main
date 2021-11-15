using ComponentLib;
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
    public partial class TemplateEditor : ComponentBase
    {
        [Inject]
        public IJSRuntime JSRT { get; set; }

        [Inject]
        public IReportingService ReportingService { get; set; }

        [Inject]
        IStringLocalizer<CommonResources> Localizer { get; set; }

        [Inject]
        public HttpInterceptorService InterceptorService { get; set; }

        [Parameter]
        public ReportTemplate ReportTemplate { get; set; } = new ReportTemplate();

        [Parameter]
        public EventCallback TemplateEditedEvent { get; set; }

        public ReportHeader ReportHeader { get; set; } = new ReportHeader();

        public Dictionary<string, string> Fields { get; set; } = new Dictionary<string, string>();

        public List<KeyValuePair<string, string>> OrderedFields { get; set; }

        public Confirm DeleteHeaderConfirm { get; set; }

        public Confirm DeleteTemplateConfirm { get; set; } 

        protected override void OnInitialized()
        {
            InterceptorService.RegisterEvents();

            InitFields();          
        }

        #region "Init"

        protected override void OnParametersSet()
        {
            InitFields();
            base.OnParametersSet();
        }

        public void InitFields()
        {
            Fields = new Dictionary<string, string>();
            var fields = ReportTemplate.FieldsOrder;
            SetFields(fields);
            OrderedFields = Fields.ToList();
        }

        public void SetFields(string fields)
        {
            foreach (var field in fields.Split(','))
                Fields.Add(field.Split(':')[0], field.Split(':')[1]);
        }

        public async Task GetReportTemplate()
        {
            ReportTemplate = await ReportingService.GetReportTemplate(ReportTemplate.Id);

            StateHasChanged();
        }
        #endregion


        #region "Template"

        public void DeleteTemplate()
        {
            DeleteTemplateConfirm.ModalShow();
        }
        public async Task DeleteTemplateConfirmEvent(bool confirmed)
        {
            if (confirmed)
            {
                await ReportingService.DeleteReportTemplate(ReportTemplate.Id);
                await TemplateEditedEvent.InvokeAsync(null);

                StateHasChanged();

                await JSRT.InvokeVoidAsync("Toast", Localizer["Changes Saved Successfully"].Value);
            }
        }

        public async Task ChangeTemplateState()
        {
            if (ReportTemplate.Status)
                return;

            await ReportingService.ChangeTemplateState(ReportTemplate.Id);
            await TemplateEditedEvent.InvokeAsync(null);

            StateHasChanged();

            await JSRT.InvokeVoidAsync("Toast", Localizer["Changes Saved Successfully"].Value);
        }


        #endregion


        #region "Report Header"
        public async Task SaveReportHeader()
        {
            ReportHeader.ReportTemplateId = ReportTemplate.Id;
            await ReportingService.SaveReportHeader(ReportHeader);

            await TemplateEditedEvent.InvokeAsync(null);

            await JSRT.InvokeVoidAsync("Toast", Localizer["Changes Saved Successfully"].Value);
        }

        int HeaderToDelete = 0;
        public void DeleteHeaedr(int id)
        {
            HeaderToDelete = id;
            DeleteHeaderConfirm.ModalShow();
        }
        public async Task DeleteHeaderConfirmEvent(bool confirmed)
        {
            if (confirmed)
            {

                await ReportingService.DeleteReportHeader(HeaderToDelete);
                await TemplateEditedEvent.InvokeAsync(null);

                await JSRT.InvokeVoidAsync("Toast", Localizer["Changes Saved Successfully"].Value);
            }
        }

        #endregion


        #region "Report Fields"
        public OrdarableList<KeyValuePair<string, string>> FieldsOrderList { get; set; }
        public void RemoveFiled(string key)
        {
            Fields.Remove(key);
            OrderedFields = Fields.ToList();
            StateHasChanged();
        } 
        public void ResetFields()
        {
            var typeName = ReportTemplate.ReportableTable.TypeName;
            var type = ReflectionAccessor.GetType(typeName);
            if (type == null) return;

            Fields = AttributeAccessor.GetPropsWithNames(type, new List<string>() { typeName });
            OrderedFields = Fields.ToList();

            StateHasChanged();
        }

        public async Task SaveFields()
        {
            var fieldsTemplate = "";
            foreach (var field in OrderedFields)
                fieldsTemplate += $"{field.Key}:{field.Value},";

            fieldsTemplate = fieldsTemplate.Remove(fieldsTemplate.Length - 1, 1);

            ReportTemplate.FieldsOrder = fieldsTemplate;
            await SaveTemplate();

            await TemplateEditedEvent.InvokeAsync(null);

            var msg = Localizer["Changes Saved Successfully"];
            await JSRT.InvokeVoidAsync("Toast", msg.Value);

        }
        #endregion

        public async Task SaveTemplate()
        {
            ReportTemplate.ReportableTable = null;
            await ReportingService.SaveReportFields(ReportTemplate);
        }

    }
}
