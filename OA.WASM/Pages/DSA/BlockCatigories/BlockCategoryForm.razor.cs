using Microsoft.AspNetCore.Components;
using OA.Domin;
using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.BlockCatigories
{
    public partial class BlockCategoryForm : ComponentBase
    {

        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public BlockCategory BlockCategory { get; set; } = new BlockCategory();

        public Dictionary<string, string> BlockCategoryTypeItems { get; set; } = new Dictionary<string, string>();

        public string Active { get; set; } = "";

        protected override void OnInitialized()
        {
            Active = (IsEdit) ? "active" : "";

            BlockCategoryTypeItems = StaticIndexes.BlockCategoryTypes;
        }

    }
}
