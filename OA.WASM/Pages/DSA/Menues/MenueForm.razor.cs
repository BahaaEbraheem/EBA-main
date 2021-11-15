using Microsoft.AspNetCore.Components;
using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OA.WASM.Shared;
using OA.Domin;

namespace OA.WASM.Pages.DSA.Menues
{
    public partial class MenueForm : ComponentBase
    {

        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public Menue Menue { get; set; } = new Menue();

        [Parameter]
        public Dictionary<string, string> MenueCategoryItems { get; set; } = new Dictionary<string, string>();

        [Parameter]
        public Dictionary<string, string> MenueItems { get; set; } = new Dictionary<string, string>();

        public Dictionary<string, string> MenuTypeItems { get; set; } = new Dictionary<string, string>();

        public string Active { get; set; } = "";

        public UploadFile FileUploadControl { get; set; }
        public UploadFile ImageUploadControl { get; set; }

        public bool UploadBusy { get; set; }

        protected override void OnInitialized()
        {
            Active = (IsEdit) ? "active" : "";

            MenuTypeItems = StaticIndexes.MenueTypes;

        }

    }
}
