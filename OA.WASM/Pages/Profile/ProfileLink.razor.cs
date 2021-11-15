using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OA.WASM.Pages.Profile
{
    public partial class ProfileLink : ComponentBase
    {
        [Inject]
        public ILocalStorageService LocalStorageService { get; set; }


        [CascadingParameter(Name = "AppSettings")]
        public Dictionary<string, string> AppSettings { get; set; } = new Dictionary<string, string>();

        // Load Profile Image For User From LocalStorage or API

        [Parameter]
        public string UserImagePath { get; set; } = "";

        public string ImgData { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await SetImg();
            //Subscribe to Profile pic changed event in profileManager
            ProfileManager.OnProfilePicChanged += async () =>
            {
                await SetImg();
            };

        }

        public async Task SetImg()
        {
            UserImagePath = await LocalStorageService.GetItemAsync<string>("ProfilePic");

            ImgData = (!string.IsNullOrEmpty(UserImagePath)) ? UserImagePath : "https://placehold.co/600x400";

            StateHasChanged();
        }

    }
}
