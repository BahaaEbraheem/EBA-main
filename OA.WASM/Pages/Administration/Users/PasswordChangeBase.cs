using ComponentLib;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using OA.Domin.Requests;
using OA.Domin.Resources;
using OA.WASM.Services;
using OA.WASM.Services.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.Administration.Users
{
    public class PasswordChangeBase : ComponentBase, IDisposable
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
        public string UserId { get; set; }

        [Parameter]
        public EventCallback PasswordChangedEvent { get; set; }

        public ServerValidation Validation { get; set; }

        public ResetPasswordRequest ResetPassword { get; set; } = new ResetPasswordRequest();


        protected override void OnInitialized()
        {
            InterceptorService.RegisterEvents();

            ResetPassword.Id = UserId;

        }

        public bool ResetBusy { get; set; }
        public async Task HandleResetPassword()
        {
            var result = await AdministrationService.ResetPassword(ResetPassword);

            if (result.HasErrors)
            {
                await JSRT.InvokeVoidAsync("Toast", Localizer["Validation Errors"].Value, "error", 10000);
                Validation.ShowValidation(result.ValidationErrors);
            }
            else
            {
                await JSRT.InvokeVoidAsync("Toast", Localizer["Changes Saved Successfully"].Value);
                if (PasswordChangedEvent.HasDelegate)
                {
                    await PasswordChangedEvent.InvokeAsync(null);
                }
            }

        }

        public void Dispose()
        {
            InterceptorService.DisposeEvents();
        }
    }
}
