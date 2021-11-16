//using OA.Domin;
//using OA.Domin.DSA;
//using OA.Domin.DSA.Indexes;
//using OA.WASM.Shared;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace OA.WASM.Pages.DSA.CorporateBeneficiaries
//{
//    public class CorporateBeneficiariesListBase : ListBase<CorporateBeneficiary>
//    {

//        public async Task GetIndexDataEvent(string indexName)
//        {
//            var indexData = new List<IndexData>();
//            if (indexName == nameof(Person))
//                indexData = await GetIndexData<Person>();
//            if (indexName == nameof(Activity))
//                indexData = await GetIndexData<Activity>();

//            GridFilterRef.IndexDatas = indexData;
//        }

//    }
//}
