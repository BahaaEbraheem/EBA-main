using AutoMapper.Internal;
using ComponentLib;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using OA.Domin.Administration;
using OA.Domin.Notifications;
using OA.Domin.Resources;
using OA.WASM.Services;
using OA.WASM.Services.Administration;
using OA.WASM.Services.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.Notifications
{
    public class PushNotificationsBase : ComponentBase, IDisposable
    {

        [Inject]
        public IAdministrationService AdministrationService { get; set; } 

        [Inject]
        public INotificationServices NotificationServices { get; set; }

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Inject]
        public HttpInterceptorService InterceptorService { get; set; }

        [Inject]
        public IJSRuntime JSRT { get; set; }

        public Notification Notification { get; set; } = new Notification();

        public Dictionary<string, string> Roles { get; set; } = new Dictionary<string, string>();

        public Dictionary<string, string> Users { get; set; } = new Dictionary<string, string>();

        public ServerValidation Validation { get; set; }
        
        public List<string> Errors { get; set; }

        protected async override Task OnInitializedAsync()
        {
            InterceptorService.RegisterEvents();

            var roles = await AdministrationService.GetAllRoles();
            var users = await AdministrationService.IndexGetAllUsers();

            roles.ForAll(r => Roles.Add(r.Id, r.Name));
            users.ForAll(u => Users.Add(u.Id, u.Email));

        }

        public bool PushBusy = false;
        public async Task BroadCast()
        {
            if (PushBusy) return;

            if (!Validate())
            {
                Validation.ShowValidation(Errors);
                return;
            }

            PushBusy = true;
            await NotificationServices.BroadCast(Notification);

            PushBusy = false;
            await JSRT.InvokeVoidAsync("Toast", "Notification Sent");
            
        }

        public async Task PushToUser()
        {
            if (PushBusy) return;

            if (!Validate())
            {
                Validation.ShowValidation(Errors);
                return;
            }
            if (string.IsNullOrEmpty(Notification.UserId) || !Users.Keys.Contains(Notification.UserId))
            {
                Errors.Add(Localizer["No User Selected"].Value);
                Validation.ShowValidation(Errors);
                return;
            }

            PushBusy = true;
            await NotificationServices.PushToUser(Notification);

            PushBusy = false;
            await JSRT.InvokeVoidAsync("Toast", "Notification Sent");
        }

        public async Task PushToRole()
        {
            if (PushBusy) return;
            
            if (!Validate()) 
            {
                Validation.ShowValidation(Errors);
                return;
            }            
            if (string.IsNullOrEmpty(Notification.UserId) || !Roles.Keys.Contains(Notification.UserId))
            {
                Errors.Add(Localizer["No Role Selected"].Value);
                Validation.ShowValidation(Errors);
                return;
            }

            PushBusy = true;
            await NotificationServices.PushToRoleGroup(Notification);

            PushBusy = false;
            await JSRT.InvokeVoidAsync("Toast", "Notification Sent");
        }

        public bool Validate()
        {
            Errors = new List<string>();

            if (string.IsNullOrEmpty(Notification.Title))
                Errors.Add(Localizer["Notification Title Empty"].Value);
            if(string.IsNullOrEmpty(Notification.Body))
                Errors.Add(Localizer["Notification Body Empty"].Value);

            return Errors.Count == 0;
        }



        public void Dispose()
        {
            InterceptorService.DisposeEvents();
        }

    }
}
