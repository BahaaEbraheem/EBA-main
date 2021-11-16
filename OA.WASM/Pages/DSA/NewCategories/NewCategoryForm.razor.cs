using Microsoft.AspNetCore.Components;
using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.NewCategories
{
    public partial class NewCategoryForm : ComponentBase
    {

        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public NewCategory NewCategory { get; set; } = new NewCategory();

        public string Active { get; set; } = "";

        public UploadFile ImageUploadControl { get; set; }

        public bool UploadBusy { get; set; }

        protected override void OnInitialized()
        {
            Active = (IsEdit) ? "active" : "";

        }

    }
}
