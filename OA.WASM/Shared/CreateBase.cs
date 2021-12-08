using ComponentLib;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using OA.Domin.Resources;
using OA.WASM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Shared
{
    public class CreateBase<T> : ComponentBase, IDisposable where T : class, new()
    {
        [Inject]
        public HttpInterceptorService InterceptorService { get; set; }

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ServerValidation ServerValidation { get; set; } = new ServerValidation();

        [Inject]
        public ServiceBase<T> CreateService { get; set; }

        [Inject]
        public IJSRuntime JSRT { get; set; }

        [Inject]
        public IServiceProvider ServiceProvider { get; set; }

        public T EntityItem { get; set; } = new T();

        public bool CreateBusy { get; set; } = false;

        protected async override Task OnInitializedAsync()
        {
            InterceptorService.RegisterEvents();
            await base.OnInitializedAsync();
        }

        public async Task HandelSubmit()
        {
            if (CreateBusy) return;

            CreateBusy = true;
            
            var result = await CreateService.Create(EntityItem);
            
            if(!result.HasErrors)
                await JSRT.InvokeVoidAsync("Toast", Localizer["Changes Saved Successfully"].Value);
            else
            {
                if (result.ValidationErrors.Any())
                {
                    await JSRT.InvokeVoidAsync("Toast", Localizer["Validation Errors"].Value, "error");
                }
                else
                    await JSRT.InvokeVoidAsync("Toast", Localizer["Something Went Wrong"].Value, "error");

            }

            CreateBusy = false;           
        }

        //public virtual void ShowValidation(){}

        public async Task<Dictionary<string, string>> GetIndexData<U>() where U : class
        { 
            var service = (ServiceBase<U>)ServiceProvider.GetService(typeof(ServiceBase<U>));
            var list = await service.IndexGet();

            var dic = new Dictionary<string, string>();
            list.ForEach(i => dic.Add($"{i.Id}", $"{i.Name}"));
          

            return dic;
        }

        public void Dispose()
        {
            InterceptorService.DisposeEvents();
        }

    }
}
