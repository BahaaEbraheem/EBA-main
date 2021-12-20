using ComponentLib;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using OA.Domin.Administration;
using OA.Domin.Requests;
using OA.Domin.Resources;
using OA.WASM.Services;
using OA.WASM.Services.Administration;
using OA.WASM.Services.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.Administration.Users
{
    public class UserEditBase : ComponentBase, IDisposable
    {

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Inject]
        public HttpInterceptorService InterceptorService { get; set; }

        [Inject]
        public IAdministrationService AdministrationService { get; set; }
        [Inject]
        public IJSRuntime JSRT { get; set; }


        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public bool ProfileUse { get; set; } = false;

        public CustomUser User { get; set; } = new CustomUser();

        public Dictionary<CustomRole, bool> SelectedRoles = new Dictionary<CustomRole, bool>();

        public CheckBoxList<CustomRole> RolesChecks { get; set; }

        public ServerValidation Validation { get; set; }

        public Confirm Confirm { get; set; }

        public ResetPasswordRequest ResetPassword { get; set; } = new ResetPasswordRequest();

        public bool ResetBusy { get; set; }

        protected async override Task OnInitializedAsync()
        {
            InterceptorService.RegisterEvents();
            await Get(Id);
        }


        public async Task Get(string id)
        {            
            User = await AdministrationService.GetUser(id);

            ResetPassword.Id = User.Id;

            if (!ProfileUse)
            {
                var allRoles = await AdministrationService.GetAllRoles();
                SetSelectedRoles(User.Roles, allRoles);
            }
        }

        public void SetSelectedRoles(IEnumerable<CustomRole> userRoles, IEnumerable<CustomRole> allRoles)
        {
            var userRolesId = userRoles.Select(ur => ur.Id);

            foreach (var role in allRoles)
                if (userRolesId.Contains(role.Id))
                    SelectedRoles.Add(role, true);
                else
                    SelectedRoles.Add(role, false);
        }


        public bool EditBusy { get; set; } = false;
        public async Task HandleSubmit()
        {
            if (EditBusy) return;

            EditBusy = true;

            if(!ProfileUse)
                SetSelectedRoles();

            var result = await AdministrationService.UpdateUser(User);

            if (result.HasErrors)
            {
                await JSRT.InvokeVoidAsync("Toast", Localizer["Validation Errors"].Value, "error", 10000);
                Validation.ShowValidation(result.ValidationErrors);
            }
            else
                await JSRT.InvokeVoidAsync("Toast", Localizer["Changes Saved Successfully"].Value);

            EditBusy = false;
        }

        public void SetSelectedRoles()
        {
            var selected = RolesChecks.Selected;
            var selectedRoles = new List<CustomRole>();
            foreach (var selectedrole in selected)
                if (selectedrole.Value)
                    selectedRoles.Add(selectedrole.Key);

            User.Roles = selectedRoles;
        }

        public void DeleteItem()
        {
            Confirm.ModalShow();
        }

        public async Task DeleteConfirm(bool confirmed)
        {
            if (confirmed)
            {
                await AdministrationService.DeleteUser(User.Id);

                await JSRT.InvokeVoidAsync("Toast", Localizer["Changes Saved Successfully"].Value);

            }
        }

        public async Task HandleResetPassword()
        {
            var result = await AdministrationService.ResetPassword(ResetPassword);

            if (result.HasErrors)
            {
                await JSRT.InvokeVoidAsync("Toast", Localizer["Validation Errors"].Value, "error", 10000);
                Validation.ShowValidation(result.ValidationErrors);
            }
            else
                await JSRT.InvokeVoidAsync("Toast", Localizer["Changes Saved Successfully"].Value);

        }

        public void Dispose()
        {
            InterceptorService.DisposeEvents();
        }
    }
}
