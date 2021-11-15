using Microsoft.AspNetCore.Components;
using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.EventCategoryTranslations
{
    public partial class EventCategoryTranslationForm : ComponentBase
    {

        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public EventCategoryTranslation EventCategoryTranslation { get; set; } = new EventCategoryTranslation();

        [Parameter]
        public Dictionary<string, string> EventCategoryItems { get; set; } = new Dictionary<string, string>();

        public string Active { get; set; } = "";

        public bool UploadBusy { get; set; }

        protected override void OnInitialized()
        {
            Active = (IsEdit) ? "active" : "";
        }

    }
}
