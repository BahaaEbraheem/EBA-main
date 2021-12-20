using BlazorDownloadFile;
using ComponentLib;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using OA.Domin;
using OA.Domin.DataFilter;
using OA.Domin.RequestFeatures;
using OA.Domin.Requests;
using OA.Domin.Resources;
using OA.Domin.Settings;
using OA.WASM.Services;
using OA.WASM.Services.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Shared
{
    public class ListBase<T> : ComponentBase, IDisposable where T : class, new()
    {

        [Inject]
        public ServiceBase<T> ListService { get; set; }

        [Inject]
        public IBlazorDownloadFileService DownloadFileService { get; set; }

        [Inject]
        public IServiceProvider ServiceProvider { get; set; }

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Inject]
        public HttpInterceptorService InterceptorService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public IEnumerable<T> ListData { get; set; }

        public Confirm Confirmation { get; set; }

        public PagingMetaData PagingMetaData { get; set; } = new PagingMetaData();

        public RequestParameters PagingParameters { get; set; } = new RequestParameters();

        public GridFilter<T> GridFilterRef { get; set; }

        protected override async Task OnInitializedAsync()
        {
            InterceptorService.RegisterEvents();

            await Get();
        }

        public async Task Get()
        {
            var pagedResponce = await ListService.Get(PagingParameters);
            ListData = pagedResponce.Items;
            PagingMetaData = pagedResponce.PagingData;
        }

        public bool GetBusy = false;
        public async Task SearchEvent(IEnumerable<FilterParams> filters)
        {
            if (GetBusy) return;

            GetBusy = true;

            PagingParameters.FilterParams = filters;
            PagingParameters.Gather = GridFilterRef.Gather;
            await Get();

            GetBusy = false;
        }

        public async Task SelectedPageEvent(int page)
        {
            if (GetBusy) return;

            GetBusy = true;

            PagingParameters.PageNumber = page;
            await Get();

            GetBusy = false;
        }

        public int ToDelete { get; set; }
        public void DeleteItem(int id)
        {
            ToDelete = id;
            Confirmation.ModalShow();
        }

        public async Task ConfirmationEvent(bool confirmed)
        {
            if (confirmed)
            {
                await ListService.Delete(ToDelete);
                await Get();
            }
        }

        public bool ExportBusy = false;
   

 

        public async Task Export(string exportAs, string typeName)
        {
            if (ExportBusy) return;

            ExportBusy = true;

            var contentType = FileSettings.FileMemeTypes[exportAs];

            ExportRequest exportRequest = new ExportRequest()
            {
                TypeName = typeName,
                FilterOptions = PagingParameters,
                ExportAs = exportAs
            };

            var bytes = await ListService.Export(exportRequest);

            await DownloadFileService.DownloadFile("Report", bytes, contentType);

            ExportBusy = false;

        }

        public async Task<List<IndexData>> GetIndexData<U>() where U : class
        {
            var service = (ServiceBase<U>)ServiceProvider.GetService(typeof(ServiceBase<U>));
            var list = await service.IndexGet();

            return list;
        }

        public void Dispose() => InterceptorService.DisposeEvents();

    }
}
