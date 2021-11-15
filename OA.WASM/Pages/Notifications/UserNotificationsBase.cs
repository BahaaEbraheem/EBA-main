using Microsoft.AspNetCore.Components;
using OA.WASM.Services;
using OA.WASM.Services.Auth;
using OA.WASM.Services.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OA.Domin.Notifications;
using Microsoft.Extensions.Localization;
using OA.Domin.Resources;

namespace OA.WASM.Pages.Notifications
{
    public class UserNotificationsBase : ComponentBase, IDisposable
    {
        [Inject]
        public INotificationServices NotificationServices { get; set; }

        [Inject]
        public HttpInterceptorService InterceptorService { get; set; }

        [Inject]
        public LocalAuthenticationStateProvider StateProvider { get; set; }

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        public string UserId { get; set; }

        public int UnSeenCount { get; set; }

        public string ActiveNotList { get; set; } = "";

        public List<Notification> UnSeenNotifications { get; set; } = new List<Notification>();

        protected async override Task OnInitializedAsync()
        {
            InterceptorService.RegisterEvents();

            //Subscribe To OnNotification Event
            NotificationPortalBase.OnNotification += (Notification) =>
            {
                UnSeenCount++;
                UnSeenNotifications.Insert(0, Notification);
                StateHasChanged();
            };

            var user = await StateProvider.GetCurrentUserAsync();
            var UserIdClaim = (user != null)? user.Claims.FirstOrDefault(u => u.Type == "Id") : null;
            UserId = (UserIdClaim != null)? UserIdClaim.Value : UserId;
            
            if(!string.IsNullOrEmpty(UserId))
                await GetUserNotifications();
        }

        public async Task GetUserNotifications()
        {
            var notifications = await NotificationServices.GetUserUnSeenNotifications();
            UnSeenNotifications = notifications.ToList();
            UnSeenCount = UnSeenNotifications.Count();
        }

        public void NotificationListToggle()
        {
            ActiveNotList = (ActiveNotList == "") ? "active" : ""; 
        }

        public async Task MarkAllAsSeen()
        {
            await NotificationServices.SetAsSeen();

            UnSeenNotifications = new List<Notification>();
            UnSeenCount = 0;
        }


        public string TimeSpan(DateTime date)
        {
            var span = DateTime.Now - date;

            if (span.TotalSeconds < 60)
                return $"{Localizer["Now"].Value}";
            if (span.TotalMinutes < 60)
                return $"{Localizer["{0} minutes ago", Math.Floor(span.TotalMinutes)].Value}";
            if (span.TotalHours < 24)
                return $"{Localizer["{0} hours ago", Math.Floor(span.TotalHours)].Value}";
            if (span.TotalDays < 31)
                return $"{Localizer["{0} days ago", Math.Floor(span.TotalDays)].Value}";
            if (span.TotalDays < 365)
                return $"{Localizer["about {0} month ago", Math.Floor((double)span.TotalDays / 30)].Value}";
            else
                return $"{Localizer["about {0} year ago", Math.Floor((double)span.TotalDays / 365)].Value}";
        }

        public void Dispose()
        {
            InterceptorService.DisposeEvents();
        }
    }
}
