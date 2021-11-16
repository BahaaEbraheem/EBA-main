﻿using OA.Domin;
using OA.Domin.DSA;
using OA.Domin.DSA.Indexes;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.NewTranslations
{
    public class NewTranslationsListBase : ListBase<NewTranslation>
    {

        public async Task GetIndexDataEvent(string indexName)
        {
            var indexData = new List<IndexData>();
            if (indexName == nameof(New))
            {
                indexData = await GetIndexData<New>();
            }
            if (indexName == nameof(Language))
            {
                indexData = await GetIndexData<Language>();
            }

            GridFilterRef.IndexDatas = indexData;
        }

    }
}
