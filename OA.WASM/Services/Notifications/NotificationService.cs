using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using OA.Domin.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OA.WASM.Services.Notifications
{
    public class NotificationService : INotificationServices
    {
        private readonly HttpClient httpClient;
        private HubConnection HubConnection;
        private ILocalStorageService localStorageService;
        private string endpoint;
        private string hubendpoint;

        public NotificationService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            this.localStorageService = localStorageService;
            this.endpoint = "api/Notifications";
            hubendpoint = $"{httpClient.BaseAddress}hubs/notificationHub";
        }

        public async Task ConnectToServer()
        {
            var accessToken = await GetAccessToken();

            HubConnection = new HubConnectionBuilder()
                                .WithUrl($"{hubendpoint}", options =>
                                {
                                    options.SkipNegotiation = true;
                                    options.Transports = HttpTransportType.WebSockets;
                                    options.AccessTokenProvider = GetAccessToken;
                                })
                                .Build();

            await HubConnection.StartAsync();            
        }

        public async Task DisConnectWithServer()
        {
            await HubConnection.StopAsync();
        }

        public async Task<string> GetAccessToken()
        {
            return await localStorageService.GetItemAsync<string>("AccessToken");
        }

        public HubConnection GetHubConnection()
        {
            return HubConnection;
        }

        public async Task<Notification> BroadCast(Notification notification)
        {
            var response = await httpClient.PostAsJsonAsync<Notification>($"{endpoint}/BroadCast", notification);
            //var notification1 = response.Content.ReadFromJsonAsync<Notification>();

            return notification;
        }
        public async Task<Notification> PushToRoleGroup(Notification notification)
        {
            var response = await httpClient.PostAsJsonAsync<Notification>($"{endpoint}/PushToRoleGroup", notification);

            return notification;
        }

        public async Task<Notification> PushToUser(Notification notification)
        {
            var response = await httpClient.PostAsJsonAsync<Notification>($"{endpoint}/PushToUser", notification);

            return notification;
        }

        public async Task<IEnumerable<Notification>> GetUserNotifications()
        {
            var response = await httpClient.GetAsync($"{endpoint}/GetUserNotification");
            var content = await response.Content.ReadAsStringAsync();

            var notifications =  JsonConvert.DeserializeObject<IEnumerable<Notification>>(content);

            return notifications;

        }

        public async Task<IEnumerable<Notification>> GetUserUnSeenNotifications()
        {
            var response = await httpClient.GetAsync($"{endpoint}/GetUserUnSeenNotification");
            var content = await response.Content.ReadAsStringAsync();

            var notifications = JsonConvert.DeserializeObject<IEnumerable<Notification>>(content);

            return notifications;

        }

        public async Task SetAsSeen()
        {
            await httpClient.GetAsync($"{endpoint}/SetAsSeen");
        }

    }
}
