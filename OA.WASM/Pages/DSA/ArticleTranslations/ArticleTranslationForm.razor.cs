using Microsoft.AspNetCore.Components;
using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.ArticleTranslations
{
    public partial class ArticleTranslationForm : ComponentBase
    {

        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public ArticleTranslation ArticleTranslation { get; set; } = new ArticleTranslation();

        [Parameter]
        public Dictionary<string, string> ArticleItems { get; set; } = new Dictionary<string, string>();
        [Parameter]
        public Dictionary<string, string> LanguageItems { get; set; } = new Dictionary<string, string>();
        public string Active { get; set; } = "";

        public bool UploadBusy { get; set; }

        protected override void OnInitialized()
        {
            ArticleTranslation.Content ??= "type yout content here ....";

            Active = (IsEdit) ? "active" : "";
        }

    }
}
