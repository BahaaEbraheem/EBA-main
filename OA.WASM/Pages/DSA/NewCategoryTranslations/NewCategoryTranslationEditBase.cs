using OA.Domin.DSA;
using OA.Domin.DSA.Indexes;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.NewCategoryTranslations
{
    public class NewCategoryTranslationEditBase : EditBase<NewCategoryTranslation>
    {

        public Dictionary<string, string> NewCategoryItems { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> LanguageItems { get; set; } = new Dictionary<string, string>();

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            NewCategoryItems = await GetIndexData<NewCategory>();
            LanguageItems = await GetIndexData<Language>();
        }


    }
}
