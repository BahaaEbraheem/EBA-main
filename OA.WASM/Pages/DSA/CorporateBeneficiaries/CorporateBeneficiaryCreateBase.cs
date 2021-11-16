//using OA.Domin.DSA;
//using OA.Domin.DSA.Indexes;
//using OA.WASM.Shared;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace OA.WASM.Pages.DSA.CorporateBeneficiaries
//{
//    public class CorporateBeneficiaryCreateBase : CreateBase<CorporateBeneficiary>
//    {

//        public Dictionary<string, string> ActivityItems { get; set; } = new Dictionary<string, string>();

//        protected async override Task OnInitializedAsync()
//        {
//            await base.OnInitializedAsync();

//            ActivityItems = await GetIndexData<Activity>();

//        }

//    }
//}
