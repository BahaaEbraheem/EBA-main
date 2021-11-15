using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OA.DataAccess;
using OA.Domin.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Services.Notifications
{
    public class NotificationService : INotificationService
    {

        private readonly IHubContext<NotificationHub> hubContext;
        private readonly AppDbContext dbContext;

        public NotificationService(IHubContext<NotificationHub> hubContext, AppDbContext dbContext)
        {
            this.hubContext = hubContext;
            this.dbContext = dbContext;
        }

        public async Task BroadCast(string notification)
        {
            await hubContext.Clients.All.SendAsync("notification", $"{DateTime.Now}, {notification}");
        }

        public async Task BroadCast(Notification notification)
        {
            var allUsers = dbContext.Users.ToList();
            foreach (var user in allUsers)
            {
                notification.UserId = user.Id;
                SaveNotification(notification);
            }

            var notStr = JsonConvert.SerializeObject(notification);

            await hubContext.Clients.All.SendAsync("notification", $"{notStr}");
            //await hubContext.Clients.All.SendAsync("notification", $"{DateTime.Now}, TEST");
        }

        public async Task PushToGroup(string groupId, string notification)
        {
            await hubContext.Clients.Group(groupId).SendAsync("notification", $"{DateTime.Now}, {notification}");
        }

        public async Task PushToRoleGroup(string roleId, Notification notification)
        {
            var roleUsers = dbContext.UserRoles.Where(ur => ur.RoleId == roleId).ToList();
            foreach(var user in roleUsers)
            {
                notification.UserId = user.UserId;
                SaveNotification(notification);
            }
            var notStr = JsonConvert.SerializeObject(notification);

            await hubContext.Clients.Group(roleId).SendAsync("notification", $"{notStr}");
        }

        public async Task PushToUser(string userId, string notification)
        {
            await hubContext.Clients.Group(userId).SendAsync("notification", $"{DateTime.Now}, {notification}");
        }

        public async Task PushToUser(string userId, Notification notification)
        {
            var user = dbContext.Users.Find(userId);

            notification.UserId = user.Id;
            SaveNotification(notification);

            var notStr = JsonConvert.SerializeObject(notification);

            await hubContext.Clients.Group(userId).SendAsync("notification", $"{notStr}");
        }


        public IEnumerable<Notification> GetUserNotifications(string userId)
        {
            var userNotification = dbContext.Notifications.Where(n => n.UserId == userId).OrderByDescending(n => n.Date).ToList();

            return userNotification;
        }

        public IEnumerable<Notification> GetUserUnSeenNotifications(string userId)
        {
            var userNotification = dbContext.Notifications.Where(n => n.UserId == userId && n.Seen == false).OrderByDescending(n => n.Date).ToList();

            return userNotification;
        }

        public void SetAsSeen(string userId)
        {
            var userNotification = dbContext.Notifications.Where(n => n.UserId == userId).ToList();
            foreach(var notification in userNotification)
            {
                var not = notification;
                not.Seen = true;
                dbContext.Entry(not).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        private void SaveNotification(Notification notification)
        {
            Notification newNot = new Notification
            {
                Title = notification.Title,
                Body = notification.Body,
                ImgPath = notification.ImgPath,
                UserId = notification.UserId
            };

            dbContext.Notifications.Add(newNot);
            dbContext.SaveChanges();
        }

    }
}
