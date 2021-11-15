//using Microsoft.AspNetCore.Components;
//using OA.Domin.DSA;
//using OA.WASM.Shared;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace OA.WASM.Pages.DSA.Donations
//{
//    public class DonationCreateBase : CreateBase<Donation>
//    {
//        [Parameter]
//        public string Type { get; set; } = ""; //Corp || Person

//        public Dictionary<string, string> PersonDonatorItems { get; set; } = new Dictionary<string, string>();
//        public Dictionary<string, string> CorporateDonatorItems { get; set; } = new Dictionary<string, string>();
//        public Dictionary<string, string> BeneficiaryItems { get; set; } = new Dictionary<string, string>();

//        protected async override Task OnInitializedAsync()
//        {
//            await base.OnInitializedAsync();

//            if(string.IsNullOrEmpty(Type) || Type == "Person")
//                PersonDonatorItems = await GetIndexData<PersonDonator>();
//            if(string.IsNullOrEmpty(Type) || Type == "Corp")
//                CorporateDonatorItems = await GetIndexData<CorporateDonator>();

//            BeneficiaryItems = await GetIndexData<Beneficiary>();

//        }

//    }
//}
