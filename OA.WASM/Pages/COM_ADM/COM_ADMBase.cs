using ComponentLib;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using OA.Domin;
using OA.Domin.DSA;
using OA.Domin.DSA.Indexes;
using OA.Domin.DSA.ViewModels;
using OA.Domin.Resources;
using OA.WASM.Services;
using OA.WASM.Services.Administration;
using OA.WASM.Services.COM_ADM;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor;
using OA.Domin.Administration;
using OA.Domin.Requests;
using OA.WASM.Services.Auth;


namespace OA.WASM.Pages.COM_ADM
{
    public class COM_ADMBase : ComponentBase, IDisposable
    {
        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Inject]
        public HttpInterceptorService InterceptorService { get; set; }

        [Inject]
        public ICOM_ADMService COM_ADMService { get; set; }
   
        [Inject]
        public IJSRuntime JSRT { get; set; }
        public ServerValidation Validation { get; set; }

        public Confirm Confirm { get; set; }
        [Parameter]
        public Commission Commission { get; set; } = new Commission();
       
        public CommissionMember CommissionMember { get; set; } = new CommissionMember();
        public Dictionary<AdministrationBoard, bool> SelectedRoles = new Dictionary<AdministrationBoard, bool>();
        public CheckBoxList<AdministrationBoard> RolesChecks { get; set; }

        public IEnumerable<CommissionMember> ListCommissionMember { get; set; } = new List<CommissionMember>();
        public AdministrationBoardVM Commission_admini_VM { get; set; } = new AdministrationBoardVM();
        public AdministrationBoard AdministrationBoard { get; set; } = new AdministrationBoard();
        public Dictionary<string, string> CommissionsItems { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> administrationboardsItems { get; set; } = new Dictionary<string, string>();
        public bool CreateBusy { get; private set; } = false;
        protected async override Task OnInitializedAsync()
        {
            InterceptorService.RegisterEvents();
            //await Get();
        }

        //private async Task Get()
        //{
        //    await COM_ADMService.GetAllAdministrators();
            
        //}

        public async Task HandelSubmit()
        {
            if (CreateBusy) return;

            CreateBusy = true;



            var result = await COM_ADMService.ADDCOM(Commission_admini_VM);
            

            //if (result.HasErrors)
            //{
            //    await JSRT.InvokeVoidAsync("Toast", Localizer["Validation Errors"].Value, "error", 10000);
            //    Validation.ShowValidation(result.ValidationErrors);
            //}
            
                await JSRT.InvokeVoidAsync("Toast", Localizer["Changes Saved Successfully"].Value);

            CreateBusy = false;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
