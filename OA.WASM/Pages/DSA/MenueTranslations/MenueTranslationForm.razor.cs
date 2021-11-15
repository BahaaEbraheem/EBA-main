using Microsoft.AspNetCore.Components;
using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.MenueTranslations
{
    public partial class MenueTranslationForm : ComponentBase
    {

        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public MenueTranslation MenueTranslation { get; set; } = new MenueTranslation();

        [Parameter]
        public Dictionary<string, string> MenueItems { get; set; } = new Dictionary<string, string>();

        public string Active { get; set; } = "";

        protected override void OnInitialized()
        {
            MenueTranslation.HTMLContent ??= "type your content here ...";

            Active = (IsEdit) ? "active" : "";

        }

    }
}
