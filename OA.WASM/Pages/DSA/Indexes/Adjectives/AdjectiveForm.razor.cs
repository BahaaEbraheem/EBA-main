using Microsoft.AspNetCore.Components;
using OA.Domin.DSA.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.Indexes.Adjectives
{
    public partial class AdjectiveForm : ComponentBase
    {

        //[Parameter]
        //public bool IsEdit { get; set; }

        [Parameter]
        public Adjective Adjective { get; set; } = new Adjective();

        //public string Active { get; set; } = "";

        //protected override void OnInitialized()
        //{
        //    Active = (IsEdit) ? "active" : "";

        //}

    }
}
