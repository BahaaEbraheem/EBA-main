using Microsoft.AspNetCore.Components;
using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.News
{
    public partial class NewForm : ComponentBase
    {

        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public New New { get; set; } = new New();

        [Parameter]
        public Dictionary<string, string> NewCategoryItems { get; set; } = new Dictionary<string, string>();

        public string Active { get; set; } = "";
        public int? Year { get; set; } = null;
        public UploadFile FileUploadControl { get; set; }
        public UploadFile ImageUploadControl { get; set; }

        public bool UploadBusy { get; set; }

        protected override void OnInitialized()
        {
            Active = (IsEdit) ? "active" : "";

        }

    }
}
