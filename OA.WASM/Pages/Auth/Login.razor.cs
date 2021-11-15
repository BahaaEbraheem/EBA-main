using Blazored.LocalStorage;
using ComponentLib;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;
using OA.Domain;
using OA.Domain.Requests;
using OA.Domin.Resources;
using OA.WASM.Services.Auth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OA.WASM.Pages.Auth
{
    public partial class Login : ComponentBase
    {
        [Inject]
        public IAuthService AuthService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ILocalStorageService LocalStorageService { get; set; }

        [Inject]
        AuthenticationStateProvider StateProvider { get; set; }

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Inject]
        HttpClient httpClient { get; set; }

        [CascadingParameter(Name = "AppSettings")]
        public Dictionary<string, string> AppSettings { get; set; }

        public ServerValidation ServerValidationRef { get; set; }

        public LoginRequest LoginRequest { get; set; } = new LoginRequest();


        public bool LoginBusy = false;
        public async Task HandleSubmit()
        {
            if (LoginBusy) return;

            LoginBusy = true;

            var authResult = await AuthService.LoginAsync(LoginRequest);
            if (authResult.Successed)
            {
                await LocalStorageService.SetItemAsync("AccessToken", authResult.Token);
                await LocalStorageService.SetItemAsync("RefreshToken", authResult.RefreshToken);

                var pic = (!string.IsNullOrEmpty(authResult.ProfilePic))? authResult.ProfilePic : "";
                var path = (!string.IsNullOrEmpty(pic))? Path.Combine(httpClient.BaseAddress.ToString(), pic) : "";
                await LocalStorageService.SetItemAsync("ProfilePic", path);

                await StateProvider.GetAuthenticationStateAsync();                

                NavigationManager.NavigateTo("/home");
            }
            else
            {
                //ServerValidationRef.Title = "Login Result";
                ServerValidationRef.ShowValidation(authResult.Errors.ToList());
            }

            LoginBusy = false;
        }

    }
}
