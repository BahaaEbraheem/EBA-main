using OA.Domin.DSA;
using OA.Domin.DSA.Indexes;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.MenueTranslations
{
    public class MenueTranslationEditBase : EditBase<MenueTranslation>
    {

        public Dictionary<string, string> MenueItems { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> LanguageItems { get; set; } = new Dictionary<string, string>();

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            MenueItems = await GetIndexData<Menue>();
            LanguageItems = await GetIndexData<Language>();

        }

    }
}
