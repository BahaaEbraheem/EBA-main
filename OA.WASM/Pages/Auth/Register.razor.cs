using Blazored.LocalStorage;
using ComponentLib;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using OA.Domain.Requests;
using OA.Domain.Responces;
using OA.Domin.Resources;
using OA.Domin.Settings;
using OA.WASM.Services.Auth;
using OA.WASM.Services.Settings.Extentions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.Auth
{
    public partial class Register : ComponentBase
    {
        [Inject]
        IAuthService AuthService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        [Inject]
        ILocalStorageService LocalStorageService { get; set; }

        [Inject]
        AuthenticationStateProvider StateProvider { get; set; }

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Inject]
        public IJSRuntime JSRT { get; set; }

        [CascadingParameter(Name = "AppSettings")]
        public Dictionary<string, string> AppSettings { get; set; }

        public RegisterRequest RegisterRequest { get; set; } = new RegisterRequest();

        public ServerValidation ServerValidationRef { get; set; }


        protected override void OnAfterRender(bool firstRender)
        {
            if (!AppSettings.Check("Registration", "true"))
                NavigationManager.NavigateTo("/auth/login");
        }

        public bool RegisterBusy { get; set; } = false;
        public async Task HandleSubmit()
        {
            if (RegisterBusy) return;

            RegisterBusy = true;

            if(AppSettings.Check("RegistrationAdminConfirm", "true"))
            {
                await HandleRegisterRequest();
                RegisterBusy = false;
                return;
            }

            AuthResult authResult = await AuthService.RegisterAsync(RegisterRequest);
            if(authResult != null)
            {
                if (authResult.Successed)
                {
                    if (!string.IsNullOrEmpty(authResult.Token))
                    {
                        await LocalStorageService.SetItemAsync("AccessToken", authResult.Token);
                        await LocalStorageService.SetItemAsync("RefreshToken", authResult.RefreshToken);
                        await StateProvider.GetAuthenticationStateAsync();

                        NavigationManager.NavigateTo("/home");
                    }
                    else
                        NavigationManager.NavigateTo("/auth/login");
                }
                else
                {
                    ServerValidationRef.ShowValidation(authResult.Errors.ToList());
                }                
            }

            RegisterBusy = false;
        }

        public async Task HandleRegisterRequest()
        {
            AuthResult authResult = await AuthService.RegisterRequest(RegisterRequest);
            if (authResult.Successed)
            {
                await JSRT.InvokeVoidAsync("Alert", $"{Localizer["Your Request Was Sent to Admin Confirmation , Try login In the next 24 hours"].Value}", "Welcome", "success");
            }
            else
            {
                ServerValidationRef.ShowValidation(authResult.Errors.ToList());
            }
            
        }

    }
}
