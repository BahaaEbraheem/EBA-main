using ComponentLib;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using OA.Domin;
using OA.Domin.Resources;
using OA.WASM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Shared
{
    public class EditBase<T> : ComponentBase, IDisposable where T : class, new()
    {

        [Inject]
        public HttpInterceptorService InterceptorService { get; set; }

        [Inject]
        public ServiceBase<T> EditService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Inject]
        public IJSRuntime JSRT { get; set; }

        [Inject]
        public IServiceProvider ServiceProvider { get; set; }

        [Parameter]
        public string Id { get; set; }

        public T EntityItem { get; set; } = new T();


        public Confirm Confirmation { get; set; }

        public bool EditBusy { get; set; } = false;

        protected async override Task OnInitializedAsync()
        {
            InterceptorService.RegisterEvents();

            int id = Convert.ToInt32(Id);
            EntityItem = await EditService.Get(id);
        }

        public virtual async Task HandelSubmit()
        {
            if (EditBusy) return;

            EditBusy = true;
            
            var result = await EditService.Update(EntityItem);
            
            if(!result.HasErrors)
                await JSRT.InvokeVoidAsync("Toast", Localizer["Changes Saved Successfully"].Value);
            else
            {
                if(result.ValidationErrors.Any())
                    await JSRT.InvokeVoidAsync("Toast", Localizer["Validation Errors"].Value, "error");
                else
                    await JSRT.InvokeVoidAsync("Toast", Localizer["Something Went Wrong"].Value, "error");
            }

            EditBusy = false;

            
        }

        public void DeleteItem()
        {
            Confirmation.ModalShow();
        }
        public async Task ConfirmationEvent(bool confirmed)
        {
            if (confirmed)
            {                               
                int id = (int)EntityItem.GetType().GetProperty("Id").GetValue(EntityItem);

                await EditService.Delete(id);

                await JSRT.InvokeVoidAsync("Toast", Localizer["Changes Saved Successfully"].Value);

            }
        }

        public async Task<Dictionary<string, string>> GetIndexData<U>() where U : class
        {
            var service = (ServiceBase<U>)ServiceProvider.GetService(typeof(ServiceBase<U>));
            var list = await service.IndexGet();

            var dic = new Dictionary<string, string>();
            list.ForEach(i => dic.Add($"{i.Id}", $"{i.Name}"));

            return dic;
        }

        public async Task<List<IndexData>> GetFullIndexData<U>() where U : class
        {
            var service = (ServiceBase<U>)ServiceProvider.GetService(typeof(ServiceBase<U>));
            var list = await service.IndexGet();

            return list;
        }

        public void Dispose()
        {
            InterceptorService.DisposeEvents();
        }
    }
}
