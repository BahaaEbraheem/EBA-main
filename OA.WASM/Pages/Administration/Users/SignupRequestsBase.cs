using ComponentLib;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using OA.Domin.Administration;
using OA.Domin.Resources;
using OA.WASM.Services;
using OA.WASM.Services.Administration;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.Administration.Users
{
    public class SignupRequestsBase : ComponentBase, IDisposable
    {

        [Inject]
        public IAdministrationService AdministrationService { get; set; }

        [Inject]
        public IStringLocalizer<CommonResources> Localizer {get; set;}

        [Inject]
        public HttpInterceptorService InterceptorService { get; set; }

        [Inject]
        public IJSRuntime JSRT { get; set; }

        public Confirm Confirmation { get; set; }

        public IEnumerable<SignupRequest> Requests { get; set; } = new List<SignupRequest>();

        public SignupRequest Request { get; set; } = new SignupRequest();

        protected async override Task OnInitializedAsync()
        {
            InterceptorService.RegisterEvents();

            await GetReuests();
        }

        public async Task GetReuests()
        {
            Requests = await AdministrationService.GetUnProcessedSignupRequests();
        }

        public bool ChangeBusy { get; set; }

        public void ConfirmRequest(SignupRequest request)
        {
            Request = request;
            Request.Confirmed = true;
            Confirmation.ModalShow();
        }

        public void DeclineRequest(SignupRequest request)
        {
            Request = request;
            Request.Confirmed = false;
        }

        public async Task DeclineRequestConfirmed()
        {
            if (ChangeBusy) return;

            ChangeBusy = true;

            await AdministrationService.ChangeSignUpRequestState(Request);

            ChangeBusy = false;

            await JSRT.InvokeVoidAsync("Toast", Localizer["Changes Saved Successfully"].Value);
            await JSRT.InvokeVoidAsync("Modal", "DeclineRequestModal", "hide");

            await GetReuests();
        }

        public async Task ConfirmationEvent(bool Confirmed)
        {
            if (ChangeBusy) return;

            if (Confirmed)
            {
                ChangeBusy = true;
                await AdministrationService.ChangeSignUpRequestState(Request);

                ChangeBusy = false;

                await JSRT.InvokeVoidAsync("Toast", Localizer["Changes Saved Successfully"].Value);
                await GetReuests();
            }

        }

        public void Dispose()
        {
            InterceptorService.DisposeEvents();
        }
    }
}
