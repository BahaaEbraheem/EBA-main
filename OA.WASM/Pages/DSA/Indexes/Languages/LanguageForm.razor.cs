using Microsoft.AspNetCore.Components;
using OA.Domin.DSA.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.Indexes.Languages
{
    public partial class LanguageForm : ComponentBase
    {

        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public Language Language { get; set; } = new Language();

        public string Active { get; set; } = "";

        protected override void OnInitialized()
        {
            Active = (IsEdit) ? "active" : "";

        }

    }
}
