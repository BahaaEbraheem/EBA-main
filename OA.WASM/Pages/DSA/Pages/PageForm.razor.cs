using Microsoft.AspNetCore.Components;
using OA.Domin;
using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.Pages
{
    public partial class PageForm : ComponentBase
    {

        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public Page Page { get; set; } = new Page();

        public Dictionary<string, string> PageTypeItems { get; set; } = new Dictionary<string, string>();

        public string Active { get; set; } = "";

        public UploadFile ImageUploadControl { get; set; }

        public bool UploadBusy { get; set; }

        protected override void OnInitialized()
        {
            Active = (IsEdit) ? "active" : "";

            PageTypeItems = StaticIndexes.PageTypes;
        }

    }
}
