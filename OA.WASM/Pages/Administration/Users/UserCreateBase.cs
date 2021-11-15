using ComponentLib;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using OA.Domin.Administration;
using OA.Domin.Resources;
using OA.WASM.Services;
using OA.WASM.Services.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toolbelt.Blazor;

namespace OA.WASM.Pages.Administration.Users
{
    public class UserCreateBase : ComponentBase, IDisposable
    {

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Inject]
        public HttpInterceptorService HttpInterceptorService { get; set; }

        [Inject]
        public IAdministrationService AdministrationService { get; set; }

        [Inject]
        public IJSRuntime JSRT { get; set; }

        public CustomUser User { get; set; } = new CustomUser();

        public Dictionary<CustomRole, bool> SelectedRoles { get; set; } = new Dictionary<CustomRole, bool>();

        public CheckBoxList<CustomRole> RolesChecks { get; set; }

        public bool CreateBusy { get; set; } = false;

        public ServerValidation Validation { get; set; }

        protected async override Task OnInitializedAsync()
        {
            HttpInterceptorService.RegisterEvents();

            var roles = await AdministrationService.GetAllRoles();

            foreach(var role in roles)
                SelectedRoles.Add(role, false);
            
        }

        public async Task HandleSubmit()
        {
            if (CreateBusy) return;

            CreateBusy = true;

            SetSelectedRoles();
            
            var result = await AdministrationService.AddUser(User);

            if (result.HasErrors)
            {
                Validation.ShowValidation(result.ValidationErrors);
                await JSRT.InvokeVoidAsync("Toast", Localizer["Validation Errors"].Value, "error", 10000);
            }
            else
                await JSRT.InvokeVoidAsync("Toast", Localizer["Changes Saved Successfully"].Value);

            CreateBusy = false;
        }

        public void SetSelectedRoles()
        {
            var selected = RolesChecks.Selected;
            var selectedRoles = new List<CustomRole>();
            foreach (var selectedrole in selected)
                if(selectedrole.Value)
                    selectedRoles.Add(selectedrole.Key);

            User.Roles = selectedRoles;
        }

        public void Dispose()
        {
            HttpInterceptorService.DisposeEvents();
        }

    }
}
