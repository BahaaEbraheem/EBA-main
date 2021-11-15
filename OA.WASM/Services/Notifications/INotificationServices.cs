using Microsoft.AspNetCore.SignalR.Client;
using OA.Domin.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Services.Notifications
{
    public interface INotificationServices
    {
        Task ConnectToServer();

        Task DisConnectWithServer();

        HubConnection GetHubConnection();

        Task<Notification> PushToUser(Notification notification);

        Task<Notification> PushToRoleGroup(Notification notification);

        Task<Notification> BroadCast(Notification notification);

        Task SetAsSeen();

        Task<IEnumerable<Notification>> GetUserNotifications();

        Task<IEnumerable<Notification>> GetUserUnSeenNotifications();
    }
}
