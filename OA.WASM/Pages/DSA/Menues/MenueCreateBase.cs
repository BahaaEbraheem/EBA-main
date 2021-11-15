using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.Menues
{
    public class MenueCreateBase : CreateBase<Menue>
    {

        public Dictionary<string, string> MenueCategoryItems = new Dictionary<string, string>();
        public Dictionary<string, string> MenueItems = new Dictionary<string, string>();

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            MenueCategoryItems = await GetIndexData<MenueCategory>();

            MenueItems = await GetIndexData<Menue>();
            MenueItems.Remove(EntityItem.Id.ToString());

        }

    }
}
