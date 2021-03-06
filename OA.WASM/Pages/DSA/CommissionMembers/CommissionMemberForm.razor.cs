using Microsoft.AspNetCore.Components;
using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OA.WASM.Shared;
using OA.Domin;
using static OA.Domin.StaticIndexes;
using OA.Domin.DSA.Indexes;
using OA.Domin.DSA.ViewModels;

namespace OA.WASM.Pages.DSA.CommissionMembers
{

    public partial class CommissionMemberForm : ComponentBase
    {


        [Parameter]
        public bool IsEdit { get; set; }
        [Parameter]
        public Dictionary<string, string> administrationboardsItems { get; set; } = new Dictionary<string, string>();
        [Parameter]
        public Dictionary<string, string> CommissionsItems { get; set; } = new Dictionary<string, string>();
  
        [Parameter]
        public AdministrationBoard AdministrationBoard { get; set; } = new AdministrationBoard();
        [Parameter]
        public Commission Commission { get; set; } = new Commission();
        [Parameter]
        public CommissionMember CommissionMember { get; set; } = new CommissionMember();
        public string Active { get; set; } = "";

        public UploadFile FileUploadControl { get; set; }
        public UploadFile ImageUploadControl { get; set; }

        public bool UploadBusy { get; set; }

        protected override void OnInitialized()
        {
            //Decision.Content ??= "type your content here ...";
            Active = (IsEdit) ? "active" : "";
        }

    }
}
