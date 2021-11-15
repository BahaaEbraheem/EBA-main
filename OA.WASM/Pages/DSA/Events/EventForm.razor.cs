using Microsoft.AspNetCore.Components;
using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.Events
{
    public partial class EventForm : ComponentBase
    {

        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public Event Event { get; set; } = new Event();

        [Parameter]
        public Dictionary<string, string> EventCategoryItems { get; set; } = new Dictionary<string, string>();

        public string Active { get; set; } = "";

        public UploadFile FileUploadControl { get; set; }
        public UploadFile ImageUploadControl { get; set; }

        public bool UploadBusy { get; set; }

        protected override void OnInitialized()
        {
            Active = (IsEdit) ? "active" : "";

        }

    }
}
