using OA.Domin;
using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.EventTranslations
{
    public class EventTranslationsListBase : ListBase<EventTranslation>
    {

        public async Task GetIndexDataEvent(string indexName)
        {
            var indexData = new List<IndexData>();
            if (indexName == nameof(Event))
            {
                indexData = await GetIndexData<Event>();
            }

            GridFilterRef.IndexDatas = indexData;
        }

    }
}
