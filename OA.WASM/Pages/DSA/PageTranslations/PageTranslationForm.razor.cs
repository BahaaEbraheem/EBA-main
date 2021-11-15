using Microsoft.AspNetCore.Components;
using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.PageTranslations
{
    public partial class PageTranslationForm : ComponentBase
    {

        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public PageTranslation PageTranslation { get; set; } = new PageTranslation();

        [Parameter]
        public Dictionary<string, string> PageItems { get; set; } = new Dictionary<string, string>();

        public string Active { get; set; } = "";

        public UploadFile FileUploadControl { get; set; }

        public bool UploadBusy { get; set; }

        protected override void OnInitialized()
        {
            PageTranslation.HTMLContent ??= "type your content here ...";

            Active = (IsEdit) ? "active" : "";

        }

    }
}
