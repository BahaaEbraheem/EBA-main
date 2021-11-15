using OA.Domin;
using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.PageTranslations
{
    public class PageTranslationsListBase : ListBase<PageTranslation>
    {

        public async Task GetIndexDataEvent(string indexName)
        {
            var indexData = new List<IndexData>();
            if (indexName == nameof(Page))
            {
                indexData = await GetIndexData<Page>();
            }

            GridFilterRef.IndexDatas = indexData;
        }

    }
}
