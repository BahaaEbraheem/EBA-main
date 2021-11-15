//using OA.Domin;
//using OA.Domin.DSA;
//using OA.WASM.Shared;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace OA.WASM.Pages.DSA.Donations
//{
//    public class DonationsListBase : ListBase<Donation>
//    {

//        public async Task GetIndexDataEvent(string indexName)
//        {
//            var indexData = new List<IndexData>();
//            if (indexName == nameof(PersonDonator))
//                indexData = await GetIndexData<PersonDonator>();
//            if (indexName == nameof(CorporateDonator))
//                indexData = await GetIndexData<CorporateDonator>();
//            if (indexName == nameof(Beneficiary))
//                indexData = await GetIndexData<Beneficiary>();

//            GridFilterRef.IndexDatas = indexData;
//        }

//    }
//}
