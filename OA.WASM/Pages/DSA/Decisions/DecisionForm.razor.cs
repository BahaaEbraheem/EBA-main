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

namespace OA.WASM.Pages.DSA.Decisions
{

    public partial class DecisionForm : ComponentBase
    {


        [Parameter]
        public bool IsEdit { get; set; }
        [Parameter]
        public Decision Decision { get; set; } = new Decision();
        public string Active { get; set; } = "";

        public UploadFile FileUploadControl { get; set; }
        public UploadFile ImageUploadControl { get; set; }

        public bool UploadBusy { get; set; }

        protected override void OnInitialized()
        {
            Decision.Content ??= "type your content here ...";
            Active = (IsEdit) ? "active" : "";
        }

    }
}
