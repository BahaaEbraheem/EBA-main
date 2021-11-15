using Blazored.LocalStorage;
using ComponentLib;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using OA.Domin.Requests;
using OA.Domin.Resources;
using OA.Domin.Settings;
using OA.WASM.Services;
using OA.WASM.Services.Auth;
using OA.WASM.Services.Settings.Extentions;
using OA.WASM.Services.Upload;
using OA.WASM.Shared;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OA.WASM.Pages.Profile
{
    public partial class ProfileManager : ComponentBase, IDisposable
    {
        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Inject]
        public LocalAuthenticationStateProvider StateProvider { get; set; }

        [Inject]
        public HttpInterceptorService InterceptorService { get; set; }

        [Inject]
        public IJSRuntime JSRT { get; set; }

        [Inject]
        public ILocalStorageService LocalStorageService { get; set; }

        [Inject]
        public IUploadService UploadService { get; set; }
        
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [CascadingParameter(Name = "AppSettings")]
        public Dictionary<string, string> AppSettings { get; set; } 


        public UploadFile UploadedPic { get; set; } = new UploadFile();

        public string UserId { get; set; } = "";

        public string UserName { get; set; } = "";

        public string UserImagePath { get; set; } = "";

        public Confirm Confirmation { get; set; } = new Confirm();

        public string ImgData { get; set; } = "";

        protected async override Task OnInitializedAsync()
        {
            CheckAppSettings();

            InterceptorService.RegisterEvents();

            var User = await StateProvider.GetCurrentUserAsync();

            var UserIdClaim = User.Claims.FirstOrDefault(c => c.Type == "Id");
            UserId = (UserIdClaim != null)? UserIdClaim.Value : "";

            var UserNameClaim = User.Claims.FirstOrDefault(c => c.Type == "UserName");
            UserName = (UserNameClaim != null) ? UserNameClaim.Value : "";

            //Get Profile Pic From Local Storage Or From API
            UserImagePath = await LocalStorageService.GetItemAsync<string>("ProfilePic");
            ImgData = (!string.IsNullOrEmpty(UserImagePath)) ? UserImagePath : "https://placehold.co/600x400";

        }

        protected override void OnAfterRender(bool firstRender)
        {
            CheckAppSettings();
            base.OnAfterRender(firstRender);
        }

        public void CheckAppSettings()
        {
            if (!AppSettings.Check("Profiling", "true"))
                NavigationManager.NavigateTo("/403");
        }

        public void OnValidUpload()
        {
            if (!UploadedPic.HasErrors)
            {
                //Show Preview Pefore Confirm
                ImgData = UploadedPic.Base64Img;

                Confirmation.ModalShow();
            }
        }

        public bool UploadBusy;
        public void StartPreUpload()
        {
            UploadBusy = true;
        }
        public void EndPreUpload()
        {
            UploadBusy = false;
        }

        public async Task SubmitProfilePic(bool Confirm)
        {
            if (Confirm)
            {
                UploadBusy = true;
                var content = new ProfilePicRequest()
                {
                    ImgFile = UploadedPic.Files.FirstOrDefault(),
                    userId = UserId
                };

                var path = await UploadService.UploadProfilePic(content);

                if (!string.IsNullOrEmpty(path))
                {
                    ImgData = path;
                    await LocalStorageService.SetItemAsync("ProfilePic", path);
                    await JSRT.InvokeVoidAsync("Toast", Localizer["Changes Saved Successfully"].Value);

                    //Invoke Profile pic changed event (to change the pic in all component that subscribed to this event)
                    OnProfilePicChanged.Invoke();

                }
                else
                {
                    await JSRT.InvokeVoidAsync("Toast", Localizer["Validation Errors"].Value, "error", 10000);
                    ImgData = UserImagePath;
                }

                UploadBusy = false;
            }
            else
            {
                ImgData = UserImagePath;
            }
        }

        public void Dispose()
        {
            InterceptorService.DisposeEvents();
        }

        public static event Action OnProfilePicChanged = () => { };

    }
}
