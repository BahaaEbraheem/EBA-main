using OA.Domin;
using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.Events
{
    public class EventsListBase : ListBase<Event>
    {
        public async Task GetIndexDataEvent(string indexName)
        {
            var indexData = new List<IndexData>();
            if (indexName == nameof(EventCategory))
            {
                indexData = await GetIndexData<EventCategory>();
            }

            GridFilterRef.IndexDatas = indexData;
        }
    }
}
