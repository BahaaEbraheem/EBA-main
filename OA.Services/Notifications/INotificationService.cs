using OA.Domin.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Services.Notifications
{
    public interface INotificationService
    {

        Task BroadCast(string notification);

        Task BroadCast(Notification notification);

        Task PushToUser(string userId, string notification);

        Task PushToUser(string userId, Notification notification);

        Task PushToGroup(string groupId, string notification);

        Task PushToRoleGroup(string roleId, Notification notification);

        IEnumerable<Notification> GetUserNotifications(string userId);

        IEnumerable<Notification> GetUserUnSeenNotifications(string userId);

        void SetAsSeen(string userId);
    }
}
