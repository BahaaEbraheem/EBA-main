using Microsoft.AspNetCore.Components;
using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.NewCategoryTranslations
{
    public partial class NewCategoryTranslationForm : ComponentBase
    {

        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public NewCategoryTranslation NewCategoryTranslation { get; set; } = new NewCategoryTranslation();

        [Parameter]
        public Dictionary<string, string> NewCategoryItems { get; set; } = new Dictionary<string, string>();
        [Parameter]
        public Dictionary<string, string> LanguageItems { get; set; } = new Dictionary<string, string>();
        public string Active { get; set; } = "";

        public bool UploadBusy { get; set; }

        protected override void OnInitialized()
        {
            Active = (IsEdit) ? "active" : "";
        }

    }
}
