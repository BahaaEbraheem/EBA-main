//using OA.Domin;
//using OA.Domin.DSA;
//using OA.WASM.Shared;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace OA.WASM.Pages.DSA.Beneficiaries
//{
//    public class BeneficiariesListBase : ListBase<Beneficiary>
//    {

//        public async Task GetIndexDataEvent(string indexName)
//        {
//            var indexData = new List<IndexData>();
//            if (indexName == nameof(Person))
//                indexData = await GetIndexData<Person>();

//            GridFilterRef.IndexDatas = indexData;
//        }

//    }
//}
