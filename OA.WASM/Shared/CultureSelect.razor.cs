using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using OA.Domin.ComponentFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OA.WASM.Shared
{
    public partial class CultureSelect : ComponentBase
    {
        [Inject]
        public ILocalStorageService LocalStorageService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public Action<Theme> ThemeSelectEvent { get; set; }

        public string CurrentLang { get; set; } = "EN";

        protected override async Task OnInitializedAsync()
        {
            var culture = await LocalStorageService.GetItemAsync<string>("Culture");

            Dictionary<string, string> Lang = new Dictionary<string, string>()
            {
                {"ar-SY", "AR" },
                {"en-US", "EN" }
            };

            var cult = (!string.IsNullOrEmpty(culture)) ? culture : "en-US";
            CurrentLang = Lang[cult];
            
        }

        public async Task SelectLanguage(string cult)
        {
            await LocalStorageService.SetItemAsync("Culture", cult);

            var currTheme = await LocalStorageService.GetItemAsync<Theme>("Theme");
            if(currTheme != null)
            {
                if (cult == "ar-SY")
                {
                    currTheme.Direction = "rtl";
                    currTheme.Align = "right";
                }
                else 
                { 
                    currTheme.Direction = "ltr";
                    currTheme.Align = "left";
                }

                await LocalStorageService.SetItemAsync<Theme>("Theme", currTheme);
            }

            ThemeSelectEvent.Invoke(currTheme);

            NavigationManager.NavigateTo("/", true);
            
        }

    }
}
