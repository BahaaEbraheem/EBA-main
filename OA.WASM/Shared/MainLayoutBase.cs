using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using OA.Domin.ComponentFeatures;
using OA.Domin.Settings;
using OA.WASM.Services;
using OA.WASM.Services.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Shared
{
    public class MainLayoutBase : LayoutComponentBase, IDisposable
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ILocalStorageService LocalStorageService { get; set; }

        [Inject]
        public HttpInterceptorService InterceptorService { get; set; }

        [Inject]
        public IAppSettingsService AppSettingsService { get; set; }

        public SideNav SideNavRef { get; set; }

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
            OnAppSettingFetched.Invoke();
        }

        public static event Action OnAppSettingFetched = () => {};

        public void ThemeSelected(Theme selectedTheme)
        {
            Theme = selectedTheme;
            StateHasChanged();
        }

        bool Opened = true;
        void ButtonClicked()
        {
            Opened = !Opened;
        }

        public void Navigate(string route)
        {
            NavigationManager.NavigateTo(route);
        }

        public void CloseNav()
        {
            SideNavRef.CloseNav();
        }

        public void Dispose()
        {
            InterceptorService.DisposeEvents();
        }
    }
}
