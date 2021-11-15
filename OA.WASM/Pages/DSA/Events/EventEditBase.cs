using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.Events
{
    public class EventEditBase : EditBase<Event>
    {

        public Dictionary<string, string> EventCategoryItems = new Dictionary<string, string>();

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            EventCategoryItems = await GetIndexData<EventCategory>();

        }

    }
}
