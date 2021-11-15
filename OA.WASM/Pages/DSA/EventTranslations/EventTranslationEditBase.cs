using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.EventTranslations
{
    public class EventTranslationEditBase : EditBase<EventTranslation>
    {

        public Dictionary<string, string> EventItems { get; set; } = new Dictionary<string, string>();

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            EventItems = await GetIndexData<Event>();

        }

    }
}
