using OA.Domin.DSA;
using OA.Domin.DSA.Indexes;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.NewTranslations
{
    public class NewTranslationCreateBase : CreateBase<NewTranslation>
    {

        public Dictionary<string, string> NewItems { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> LanguageItems { get; set; } = new Dictionary<string, string>();
        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            NewItems = await GetIndexData<New>();
            LanguageItems = await GetIndexData<Language>();

        }

    }
}
