using ComponentLib;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using OA.Domin.Administration;
using OA.Domin.DataFilter;
using OA.Domin.RequestFeatures;
using OA.Domin.Resources;
using OA.WASM.Services;
using OA.WASM.Services.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.Administration.Users
{
    public class UsersListBase : ComponentBase, IDisposable
    {

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public HttpInterceptorService InterceptorService { get; set; }

        [Inject]
        public IAdministrationService AdministrationService { get; set; }


        public IEnumerable<CustomUser> Users { get; set; } = new List<CustomUser>();

        public Confirm Confirmation { get; set; }

        public PagingMetaData PagingMetaData { get; set; } = new PagingMetaData();

        public RequestParameters PagingParameters { get; set; } = new RequestParameters();

        public UserFilterVM UserFilter { get; set; } = new UserFilterVM();


        protected override async Task OnInitializedAsync()
        {
            InterceptorService.RegisterEvents();

            await GetUsers();
        }

        public async Task GetUsers()
        {            
            var pagedResponce = await AdministrationService.GetAllUsers(PagingParameters);

            Users = pagedResponce.Items;
            PagingMetaData = pagedResponce.PagingData;
        }

        public async Task FilterUsers()
        {
            var filters = new List<FilterParams>();

            if (!string.IsNullOrEmpty(UserFilter.UserName))
                filters.Add(new FilterParams { ColumnName = "UserName", FilterOption = FilterOptions.Contains, FilterValue = UserFilter.UserName });
            if (!string.IsNullOrEmpty(UserFilter.Email))
                filters.Add(new FilterParams { ColumnName = "Email", FilterOption = FilterOptions.Contains, FilterValue = UserFilter.Email });
            //if (!string.IsNullOrEmpty(UserFilter.RoleId))
            //    filters.Add(new FilterParams { ColumnName = "RoleId", FilterOption = FilterOptions.Contains, FilterValue = UserFilter.UserName });

            PagingParameters.FilterParams = filters;
            PagingParameters.Gather = "AND";

            await GetUsers();
        }


        public async Task SelectedPageEvent(int page)
        {
            PagingParameters.PageNumber = page;
            await GetUsers();
        }

        public string ToDelete { get; set; }
        public void DeleteUser(string id)
        {
            ToDelete = id;
            Confirmation.ModalShow();
        }

        public async Task ConfirmationEvent(bool confirmed)
        {
            if (confirmed)
            {
                await AdministrationService.DeleteUser(ToDelete);
                await GetUsers();
            }
        }


        public void Dispose()
        {
            InterceptorService.DisposeEvents();
        }
    }
}
