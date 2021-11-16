using OA.Domin;
using OA.Domin.DSA;
using OA.Domin.DSA.Indexes;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.NewCategoryTranslations
{
    public class NewCategoryTranslationsListBase : ListBase<NewCategoryTranslation>
    {

        public async Task GetIndexDataEvent(string indexName)
        {
            var indexData = new List<IndexData>();
            if (indexName == nameof(NewCategory))
            {
                indexData = await GetIndexData<NewCategory>();
            }
            if (indexName == nameof(Language))
            {
                indexData = await GetIndexData<Language>();
            }
            GridFilterRef.IndexDatas = indexData;
        }

    }
}
