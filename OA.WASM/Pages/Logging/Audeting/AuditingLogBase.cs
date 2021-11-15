using AutoMapper.Internal;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using OA.Domin.Auditing;
using OA.Domin.Reflection;
using OA.Domin.RequestFeatures;
using OA.Domin.Requests;
using OA.Domin.Resources;
using OA.WASM.Services;
using OA.WASM.Services.Administration;
using OA.WASM.Services.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.Logging.Audeting
{
    public class AuditingLogBase : ComponentBase, IDisposable
    {
        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Inject]
        public HttpInterceptorService InterceptorService { get; set; }

        [Inject]
        public IAdministrationService AdministrationService { get; set; }

        [Inject]
        public IAuditsService AuditsService { get; set; }

        public Dictionary<string, string> Users { get; set; } = new Dictionary<string, string>();

        public Dictionary<string, string> Tables { get; set; } = ReflectionAccessor.GetEntityTypes();

        public Dictionary<string, string> Operations { get; set; } = new Dictionary<string, string> { { "Added", "Create" }, { "Modified", "Update" }, { "Deleted", "Delete" } };

        public Dictionary<string, object> OldDataDic { get; set; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewDataDic { get; set; } = new Dictionary<string, object>();

        public IEnumerable<Audit> Audits { get; set; } = new List<Audit>();

        public AuditSearchRequest AuditSearchRequest { get; set; } = new AuditSearchRequest();

        public PagingMetaData PagingMetaData { get; set; } = new PagingMetaData();

        public RequestParameters PagingParameters { get; set; } = new RequestParameters();


        protected async override Task OnInitializedAsync()
        {
            InterceptorService.RegisterEvents();

            await GetUsersIndex();

        }

        public async Task GetUsersIndex()
        {
            var users = await AdministrationService.IndexGetAllUsers();
            users.ForAll(u => Users.Add(u.Id, u.UserName));
        }

        public bool SearchBusy = false;
        public async Task HandleSearch()
        {
            if (SearchBusy) return;

            SearchBusy = true;

            var pagedResponce = await AuditsService.GetAudits(AuditSearchRequest, PagingParameters);

            Audits = pagedResponce.Items;
            PagingMetaData = pagedResponce.PagingData;

            SearchBusy = false;

        }

        public async Task SelectedPageEvent(int page)
        {
            PagingParameters.PageNumber = page;
            await HandleSearch();
        }

        public void DataChangeView(string oldData, string newData)
        {
            OldDataDic = new Dictionary<string, object>();
            NewDataDic = new Dictionary<string, object>();

            if(!string.IsNullOrEmpty(oldData)) 
                OldDataDic = JsonConvert.DeserializeObject<Dictionary<string, object>>(oldData);
            if(!string.IsNullOrEmpty(newData))
                NewDataDic = JsonConvert.DeserializeObject<Dictionary<string, object>>(newData);

        }


        public void Dispose()
        {
            InterceptorService.DisposeEvents();
        }

    }
}
