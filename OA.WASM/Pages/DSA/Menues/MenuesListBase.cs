using OA.Domin;
using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.Menues
{
    public class MenuesListBase : ListBase<Menue>
    {
        public async Task GetIndexDataEvent(string indexName)
        {
            var indexData = new List<IndexData>();

            if (indexName == "MenuCategory")
                indexData = await GetIndexData<MenueCategory>();
            if (indexName == nameof(Menue))
                indexData = await GetIndexData<Menue>();            

            GridFilterRef.IndexDatas = indexData;
        }
    }
}
