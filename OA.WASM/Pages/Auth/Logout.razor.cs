using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using OA.WASM.Services.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.Auth
{
    public partial class Logout : ComponentBase
    {
        [Inject]
        public ILocalStorageService LocalStorageService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public AuthenticationStateProvider StateProvider { get; set; }

        [Inject]
        public INotificationServices NotificationServices { get; set; }

        public async Task LogoutUser()
        {
            await NotificationServices.DisConnectWithServer();

            await LocalStorageService.RemoveItemAsync("AccessToken");
            await LocalStorageService.RemoveItemAsync("RefreshToken");
            await StateProvider.GetAuthenticationStateAsync();

            NavigationManager.NavigateTo("/auth/login");
        }

    }
}
