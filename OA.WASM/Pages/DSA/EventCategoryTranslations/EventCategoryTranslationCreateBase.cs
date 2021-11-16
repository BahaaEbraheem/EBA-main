using OA.Domin.DSA;
using OA.Domin.DSA.Indexes;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.EventCategoryTranslations
{
    public class EventCategoryTranslationCreateBase : CreateBase<EventCategoryTranslation>
    {

        public Dictionary<string, string> EventCategoryItems { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> LanguageItems { get; set; } = new Dictionary<string, string>();
        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            EventCategoryItems = await GetIndexData<EventCategory>();
            LanguageItems = await GetIndexData<Language>();
        }

    }
}
