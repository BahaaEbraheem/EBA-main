using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.News
{
    public class NewEditBase : EditBase<New>
    {

        public Dictionary<string, string> NewCategoryItems = new Dictionary<string, string>();

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            NewCategoryItems = await GetIndexData<NewCategory>();

        }

    }
}
