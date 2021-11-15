using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.PageTranslations
{
    public class PageTranslationCreateBase : CreateBase<PageTranslation>
    {

        public Dictionary<string, string> PageItems { get; set; } = new Dictionary<string, string>();

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            PageItems = await GetIndexData<Page>();

        }

    }
}
