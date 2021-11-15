using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using OA.Domin.Requests;
using OA.Domin.Resources;
using OA.WASM.Services.Auth;
using OA.WASM.Services.Settings.Extentions;
using OA.WASM.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OA.WASM.Pages.Home
{
    public partial class ForceChangePassword : ComponentBase
    {

        [CascadingParameter(Name = "AppSettings")]
        public Dictionary<string, string> AppSettings { get; set; }

        [Inject]
        public LocalAuthenticationStateProvider StateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IJSRuntime JSRT { get; set; }

        [Inject]
        public IStringLocalizer<CommonResources> Localizer {get; set;}

        [Inject]
        public ILocalStorageService LocalStorageService { get; set; }

        [Inject]
        public IAuthService AuthService { get; set; }

        public string UserId { get; set; } = "";

        public string Cause { get; set; } = "";

        protected async override Task OnInitializedAsync()
        {
            var user = await StateProvider.GetCurrentUserAsync();
            var UserIdClaim = user.Claims.FirstOrDefault(c => c.Type == "Id");
            UserId = (UserIdClaim != null) ? UserIdClaim.Value : "";

            //if User Last Password Change Match The Setting (Navigate To Home Page)
            if (ValidatePasswordSetting(user))
            {                
                ValidPasswordPolicy();
            }

        }

        public bool ValidatePasswordSetting(ClaimsPrincipal user)
        {
            //Check If Already Checked In This Session No Need For Another Check
            if (AppSettings.Check("ResetPasswordPassed", "true"))
                return true;

            if (user.IsInRole("Admin"))
                return true;

            bool FirstUseChek = false;
            var UserFirstUse = user.Claims.FirstOrDefault(c => c.Type == "FirstUse");
            var FirstUse = Convert.ToBoolean(UserFirstUse.Value);
            var ShouldChangePassword = user.Claims.FirstOrDefault(c => c.Type == "ShouldChangePassword");
            var ShouldChange = Convert.ToBoolean(ShouldChangePassword.Value);

            if (AppSettings.Check("ForceChangePasswordFirstUse", "false") || !FirstUse)
                FirstUseChek = true;

            //bool ChangeEveryChek = true;
            //if (AppSettings["ForceChangePasswordEvery"] != "0")
            //{
            //    var UserLastPasswordChange = user.Claims.FirstOrDefault(c => c.Type == "LastPasswordChange");
            //    if (!string.IsNullOrEmpty(UserLastPasswordChange.Value))
            //    {
            //        var cult = await LocalStorageService.GetItemAsync<string>("Culture");
            //        var LastPasswordChange = DateHelpers.ConvertDueCulture(UserLastPasswordChange.Value, cult);
            //        var days = Convert.ToInt32(AppSettings["ForceChangePasswordEvery"]);
            //        var timeToChange = LastPasswordChange.AddDays(days);
            //        if (DateTime.Now > timeToChange) 
            //            ChangeEveryChek = false;

            //        Cause = Localizer[$"Due To Security Policy You Have To Change Your Password Every ({days}) Days"].Value;
            //    }
            //    else
            //        ChangeEveryChek = false;               
            //}

            if (ShouldChange)
            {
                var days = Convert.ToInt32(AppSettings["ForceChangePasswordEvery"]);
                Cause = Localizer[$"Due To Security Policy You Have To Change Your Password Every ({days}) Days"].Value;
            }

            if (!FirstUseChek)
                Cause = Localizer["On Your First Use"].Value;

            return FirstUseChek && !ShouldChange;

        }

        public async Task PasswordChanged()
        {
            
            if (AppSettings.Keys.Contains("ResetPasswordPassed"))
                AppSettings["ResetPasswordPassed"] = "true";
            else 
                AppSettings.Add("ResetPasswordPassed", "true");

            await JSRT.InvokeVoidAsync("Modal", "ResetPasswordModal", "hide");

            await AuthService.LogoutUserAsync();
        }

        public void ValidPasswordPolicy()
        {
            if (AppSettings.Keys.Contains("ResetPasswordPassed"))
                AppSettings["ResetPasswordPassed"] = "true";
            else
                AppSettings.Add("ResetPasswordPassed", "true");

            NavigationManager.NavigateTo("/home");

        }

    }
}
