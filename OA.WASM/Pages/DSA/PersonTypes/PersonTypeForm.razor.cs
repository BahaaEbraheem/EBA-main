using Microsoft.AspNetCore.Components;
using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.PersonTypes
{
    public partial class PersonTypeForm : ComponentBase
    {

        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public PersonType PersonType { get; set; } = new PersonType();
        [Parameter]
        public Dictionary<string, string> PersonItems { get; set; } = new Dictionary<string, string>();
        [Parameter]
        public Dictionary<string, string> PTypeItems { get; set; } = new Dictionary<string, string>();
        
        public string Active { get; set; } = "";

        protected override void OnInitialized()
        {
            Active = (IsEdit) ? "active" : "";

        }

    }
}
