using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using OA.Domin.Resources;
using OA.WASM.Services;
using OA.WASM.Services.Settings;
using OA.WASM.Services.Settings.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.Settings
{
    public class AppSettingsBase : ComponentBase, IDisposable
    {

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Inject]
        public HttpInterceptorService InterceptorService { get; set; }

        [Inject]
        public IAppSettingsService AppSettingsService { get; set; }

        [Inject]
        public IJSRuntime JSRT { get; set; } 

        [CascadingParameter(Name = "AppSettings")]
        public Dictionary<string, string> AppSettings { get; set; }

        public bool Profiling { get; set; }
        public bool PasswordChangePoicy { get; set; }
        public bool ForceChangeFirstUse { get; set; }

        public bool ForceChangeEvery { get; set; }
        public int DaysToChangePassword { get; set; }

        public bool Registration { get; set; }
        public bool AdminConfirm { get; set; }

        protected override void OnInitialized()
        {
            InterceptorService.RegisterEvents();
            SetChekBoxes();
        }

        public void SetChekBoxes()
        {
            Profiling = AppSettings.Check("Profiling", "true");
            ForceChangeFirstUse = AppSettings.Check("ForceChangePasswordFirstUse", "true");
            ForceChangeEvery = Profiling && !AppSettings.Check("ForceChangePasswordEvery", "0");
            Registration = AppSettings.Check("Registration", "true");
            AdminConfirm = AppSettings.Check("RegistrationAdminConfirm", "true");

            PasswordChangePoicy = ForceChangeFirstUse || ForceChangeEvery;
            DaysToChangePassword = (ForceChangeEvery) ? Convert.ToInt32(AppSettings["ForceChangePasswordEvery"]) : 0;
        }

        public bool SaveBusy { get; set; } = false;
        public async Task SaveSettings()
        {
            if (SaveBusy) return;

            SaveBusy = true;

            AppSettings["Profiling"] = Profiling.ToString().ToLower();
            AppSettings["ForceChangePasswordFirstUse"] = (Profiling && PasswordChangePoicy)? ForceChangeFirstUse.ToString().ToLower() : "false";
            AppSettings["ForceChangePasswordEvery"] = (Profiling && PasswordChangePoicy && ForceChangeEvery) ? DaysToChangePassword.ToString().ToLower() : "0";

            AppSettings["Registration"] = Registration.ToString().ToLower();
            AppSettings["RegistrationAdminConfirm"] = (Registration)? AdminConfirm.ToString().ToLower() : "false";

            AppSettings["PasswordChangePoicy"] = ((Profiling && PasswordChangePoicy) && (ForceChangeFirstUse || ForceChangeEvery)).ToString().ToLower();

            AppSettings["ResetPasswordPassed"] = "false";

            await AppSettingsService.SetAppSettings(AppSettings);

            await JSRT.InvokeVoidAsync("Toast", Localizer["Changes Saved Successfully"].Value);

            SaveBusy = false;

            SetChekBoxes();
        }

        public void Dispose()
        {
            InterceptorService.DisposeEvents();
        }
    }
}
