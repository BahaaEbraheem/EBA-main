//using Microsoft.AspNetCore.Components;
//using OA.Domin;
//using OA.Domin.DSA;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace OA.WASM.Pages.DSA.Donations
//{
//    public partial class DonationForm : ComponentBase
//    {

//        [Parameter]
//        public bool IsEdit { get; set; }

//        [Parameter]
//        public Donation Donation { get; set; } = new Donation();       

//        [Parameter]
//        public Dictionary<string, string> PersonDonatorItems { get; set; } = new Dictionary<string, string>();
//        [Parameter]
//        public Dictionary<string, string> CorporateDonatorItem { get; set; } = new Dictionary<string, string>();

//        [Parameter]
//        public Dictionary<string, string> BeneficaryItems { get; set; } = new Dictionary<string, string>();

//        public Dictionary<string, string> DonatorItems { get; set; } = new Dictionary<string, string>();

//        [Parameter]
//        public string Type { get; set; }

//        public Dictionary<string, string> DonatorTypeItems { get; set; } = new Dictionary<string, string>();

//        public string Active { get; set; } = "";

//        public bool changed = true;
//        protected override void OnInitialized()
//        {
//            Active = (IsEdit) ? "active" : "";

//            DonatorTypeItems = StaticIndexes.DonarTypes;

//            if (string.IsNullOrEmpty(Type))          
//                Type = "Person";

//            DonatorTypeSelected(Type);
//        }

//        public bool IsPerson { get; set; }
//        public bool IsCorp { get; set; }
        
//        public void DonatorTypeSelected(string selected)
//        {
//            Type = selected;
//            IsPerson = Type == "Person";
//            IsCorp = Type == "Corp";
//            StateHasChanged();
//        }

//        public void DonatorSelected(string Id)
//        {
//            if (Type == "Person")
//            {
//                Donation.PersonDonatorId = Convert.ToInt32(Id);
//                Donation.CorporateDonatorId = null;
//            }
//            else
//            {
//                Donation.CorporateDonatorId = Convert.ToInt32(Id);
//                Donation.PersonDonatorId = null;
//            }
//        }
//    }
//}
