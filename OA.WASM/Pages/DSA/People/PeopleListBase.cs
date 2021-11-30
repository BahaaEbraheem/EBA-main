using OA.Domin;
using OA.Domin.DSA;
using OA.Domin.DSA.Indexes;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.People
{
    public class PeopleListBase : ListBase<Person>
    {
        public async Task GetIndexDataEvent(string indexName)
        {
            var indexData = new List<IndexData>();

            if (indexName == nameof(Nationality))
                indexData = await GetIndexData<Nationality>();
          

            GridFilterRef.IndexDatas = indexData;
        }
    }
}
