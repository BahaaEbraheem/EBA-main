using Microsoft.AspNetCore.Components;
using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.PTypes
{
    public partial class PTypeForm : ComponentBase
    {

        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public PType PType { get; set; } = new PType();

        public string Active { get; set; } = "";

        protected override void OnInitialized()
        {
            Active = (IsEdit) ? "active" : "";

        }

    }
}
