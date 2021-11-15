using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.Blocks
{
    public partial class BlockForm : ComponentBase
    {
        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public Block Block { get; set; } = new Block();

        [Parameter]
        public Dictionary<string, string> BlockCatigoryItems { get; set; } = new Dictionary<string, string>();

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
