using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using OA.Domin.ComponentFeatures;
using OA.WASM.Services;
using OA.WASM.Services.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Shared
{
    public class AuthLayoutBase : LayoutComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ILocalStorageService LocalStorageService { get; set; }

        [Inject]
        public IAppSettingsService AppSettingsService { get; set; }

        
        public Theme Theme = new Theme();

        public Dictionary<string, string> AppSettings { get; set; } = new Dictionary<string, string>();

        protected async override Task OnInitializedAsync()
        {
            //Set Theme From LocalStorage
            var currTheme = await LocalStorageService.GetItemAsync<Theme>("Theme");
            Theme = currTheme ?? new Theme();

            //Set App Settings From Server
            if (AppSettings.Count == 0)
                await SetAppSettings();
        }


        public async Task SetAppSettings()
        {
            AppSettings = await AppSettingsService.GetAppSettings();
        }

    }
}
