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
    public partial class RoleEdit : ComponentBase, IDisposable
    {

        [Inject]
        public HttpInterceptorService InterceptorService { get; set; }

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Inject]
        public IAdministrationService AdministrationService { get; set; }

        [Inject]
        public IJSRuntime JSRT { get; set; }

        [Parameter]
        public string Id { get; set; }

        public ServerValidation ServerValidation { get; set; }

        public CustomRole Role { get; set; } = new CustomRole();

        public IEnumerable<PermissionClaim> AllPermissions { get; set; } = new List<PermissionClaim>();

        public Dictionary<PermissionClaim, bool> SelectedPermissions = new Dictionary<PermissionClaim, bool>();

        public CheckBoxList<PermissionClaim> PermissionsChecks { get; set; }

        protected override async Task OnInitializedAsync()
        {
            InterceptorService.RegisterEvents();

            await GetRole();
            await GetPermissions();
            SetRolePermissions();
        }

        public async Task GetRole()
        {
            Role = await AdministrationService.GetRole(Id);
        }
        public async Task GetPermissions()
        {
            AllPermissions = await AdministrationService.GetAllPermissions();
        }

        public void SetRolePermissions()
        {
            SelectedPermissions = new Dictionary<PermissionClaim, bool>();
            var rolePemissionIds = Role.Claims.Select(ur => ur.Value);

            foreach (var permission in AllPermissions)
                SelectedPermissions.Add(permission, rolePemissionIds.Contains(permission.Value));
        }

        public bool EditBusy = false;
        public async Task HandleSubmit()
        {
            if (EditBusy) return;

            EditBusy = true;

            SetSelectedPermissions();
            var result = await AdministrationService.UpdateRole(Role);
            if (result.HasErrors)
            {
                ServerValidation.ShowValidation(result.ValidationErrors);
                EditBusy = false;
                return;
            }
            Role = result.Result;
            SetRolePermissions();

            EditBusy = false;
            await JSRT.InvokeVoidAsync("Toast", Localizer["Changes Saved Successfully"].Value);
        }

        public void SetSelectedPermissions()
        {
            var selected = PermissionsChecks.Selected;
            var selectedPermissions = new List<PermissionClaim>();
            foreach (var selectedPer in selected)
                if (selectedPer.Value)
                    selectedPermissions.Add(selectedPer.Key);

            Role.Claims = selectedPermissions;
        }


        public void Dispose()
        {
            InterceptorService.DisposeEvents();
        }
    }
}
