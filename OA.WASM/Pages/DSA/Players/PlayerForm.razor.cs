using Microsoft.AspNetCore.Components;
using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OA.WASM.Shared;
using OA.Domin;
using static OA.Domin.StaticIndexes;

namespace OA.WASM.Pages.DSA.Players
{
    public partial class PlayerForm : ComponentBase
    {

        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public Person Person { get; set; } = new Person();

        [Parameter]
        public Player Player { get; set; } = new Player();
        [Parameter]
        public Dictionary<string, string> AdjectiveItems { get; set; } = new Dictionary<string, string>();
        [Parameter]
        public Dictionary<string, string> AgeCategoryItems { get; set; } = new Dictionary<string, string>();
        public string Active { get; set; } = "";

        public UploadFile FileUploadControl { get; set; }
        public UploadFile ImageUploadControl { get; set; }

        public bool UploadBusy { get; set; }

        protected override void OnInitialized()
        {
            Active = (IsEdit) ? "active" : "";
          
            //GenderItems = StaticIndexes.Gender;



        }

    }
}
