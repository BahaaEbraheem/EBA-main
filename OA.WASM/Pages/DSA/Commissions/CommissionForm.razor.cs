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
using OA.Domin.Resources;
using ComponentLib;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using OA.Domin.Administration;
using OA.WASM.Services;
using OA.WASM.Services.Administration;
//using OA.WASM.Services.Administrator_Board;

namespace OA.WASM.Pages.DSA.Commissions
{

    public partial class CommissionForm : ComponentBase
    {
    
        public Confirm Confirm { get; set; }
        [Parameter]
        public Commission Commission { get; set; } = new Commission();


        [Parameter]
        public bool IsEdit { get; set; }
 

        public string Active { get; set; } = "";

        public UploadFile FileUploadControl { get; set; }
        public UploadFile ImageUploadControl { get; set; }

        public bool UploadBusy { get; set; }

        protected override void OnInitialized()
        {
            Active = (IsEdit) ? "active" : "";

        }

  
    }
}
