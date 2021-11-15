using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Domin.Notifications;
using OA.Services.Notifications;
using OA_API.Extentions;

namespace OA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService NotificationService;
        public NotificationsController(INotificationService notificationService)
        {
            this.NotificationService = notificationService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("PushToUser")]
        public IActionResult PushToUser(Notification notification)
        {
            NotificationService.PushToUser(notification.UserId, notification);

            return Ok(notification);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("PushToRoleGroup")]
        public IActionResult PushToRoleGroup(Notification notification)
        {
            NotificationService.PushToRoleGroup(notification.UserId, notification);

            return Ok(notification);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("BroadCast")]
        public IActionResult BroadCast(Notification notification)
        {
            NotificationService.BroadCast(notification);

            return Ok(notification);
        }

        [HttpGet("GetUserNotification")]
        public IActionResult GetUserNotification()
        {
            var userId = HttpContext.User.GetUserId();
            if (string.IsNullOrEmpty(userId)) return BadRequest();

            var userNotifications = NotificationService.GetUserNotifications(userId);

            return Ok(userNotifications);
        }

        [HttpGet("GetUserUnSeenNotification")]
        public IActionResult GetUserUnSeenNotification()
        {
            var userId = HttpContext.User.GetUserId();
            if (string.IsNullOrEmpty(userId)) return BadRequest();

            var userNotifications = NotificationService.GetUserUnSeenNotifications(userId);

            return Ok(userNotifications);
        }

        [HttpGet("SetAsSeen")]
        public IActionResult SetAsSeen()
        {
            var userId = HttpContext.User.GetUserId();
            if (string.IsNullOrEmpty(userId)) return BadRequest();

            NotificationService.SetAsSeen(userId);

            return Ok();
        }

    }
}
