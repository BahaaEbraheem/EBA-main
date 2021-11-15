using ComponentLib;
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

namespace OA.WASM.Pages.Administration.Roles
{
    public partial class RolesList : ComponentBase, IDisposable
    {

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Inject]
        public HttpInterceptorService InterceptorService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IJSRuntime JSRT { get; set; }

        [Inject]
        public IAdministrationService AdministrationService { get; set; }

        public IEnumerable<CustomRole> Roles { get; set; } = new List<CustomRole>();

        public Confirm Confirmation { get; set; }

        protected override async Task OnInitializedAsync()
        {
            InterceptorService.RegisterEvents();
            await GetRoles(); 
        }

        public async Task GetRoles()
        {
            Roles = await AdministrationService.GetAllRoles();
        }

        public async Task DeleteRole(string roleId)
        {
            //Prevent Delete Admin Role
            if (roleId == "static-role-1-admin")
            {
                await JSRT.InvokeVoidAsync("Toast", "You Can not Change Admin Role", "error", 10000);
                return;
            }

            ToDelete = roleId;
            Confirmation.ModalShow();
        }

        string ToDelete = "";
        public async Task ConfirmationEvent(bool confirmed)
        {
            if (confirmed)
            {
                await AdministrationService.DeleteRole(ToDelete);
                await GetRoles();
            }
        }

        public void Dispose()
        {
            InterceptorService.DisposeEvents();
        }
    }
}
