using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using OA.WASM.Services.Notifications;
using Microsoft.JSInterop;
using OA.Domin.Notifications;
using Newtonsoft.Json;

namespace OA.WASM.Pages.Notifications
{
    public class NotificationPortalBase : ComponentBase
    {

        [Inject]
        public INotificationServices NotificationServices { get; set; }

        [Inject]
        public IJSRuntime JSRT { get; set; }
        
        public HubConnection HubConnection = null;


        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await NotificationServices.ConnectToServer();

                HubConnection = NotificationServices.GetHubConnection();

                StartNotificationListiner();
            }
        }

        public void StartNotificationListiner() {

            HubConnection.On<string>("notification", notification => {
                //await JSRT.InvokeVoidAsync("Toast", $"{notification}");

                var notificationObj = JsonConvert.DeserializeObject<Notification>(notification);
                OnNotification.Invoke(notificationObj);

            });
        }

        public static event Action<Notification> OnNotification = (Notification) => { };

    }
}
