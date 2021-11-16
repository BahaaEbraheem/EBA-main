using Microsoft.AspNetCore.Components;
using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.NewTranslations
{
    public partial class NewTranslationForm : ComponentBase
    {

        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public NewTranslation NewTranslation { get; set; } = new NewTranslation();

        [Parameter]
        public Dictionary<string, string> NewItems { get; set; } = new Dictionary<string, string>();
        [Parameter]
        public Dictionary<string, string> LanguageItems { get; set; } = new Dictionary<string, string>();
        public string Active { get; set; } = "";

        public bool UploadBusy { get; set; }

        protected override void OnInitialized()
        {
            NewTranslation.HTMLContent ??= "type your content here ...";
            Active = (IsEdit) ? "active" : "";
        }

    }
}
