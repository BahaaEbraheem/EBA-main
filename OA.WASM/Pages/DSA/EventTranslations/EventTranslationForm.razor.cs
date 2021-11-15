using Microsoft.AspNetCore.Components;
using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.EventTranslations
{
    public partial class EventTranslationForm : ComponentBase
    {

        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public EventTranslation EventTranslation { get; set; } = new EventTranslation();

        [Parameter]
        public Dictionary<string, string> EventItems { get; set; } = new Dictionary<string, string>();

        public string Active { get; set; } = "";

        public bool UploadBusy { get; set; }

        protected override void OnInitialized()
        {
            Active = (IsEdit) ? "active" : "";
        }

    }
}
