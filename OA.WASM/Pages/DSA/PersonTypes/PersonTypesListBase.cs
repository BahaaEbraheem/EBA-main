using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OA.Domin;

namespace OA.WASM.Pages.DSA.PersonTypes
{
    public class PersonTypesListBase : ListBase<PersonType>
    {
        public async Task GetIndexDataEvent(string indexName)
        {
            var indexData = new List<IndexData>();
            if (indexName == nameof(Person))
            {
                indexData = await GetIndexData<Person>();
            }
            if (indexName == nameof(PType))
            {
                indexData = await GetIndexData<PType>();
            }
            GridFilterRef.IndexDatas = indexData;
        }
    }
}
