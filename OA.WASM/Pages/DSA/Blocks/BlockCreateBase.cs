using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.Blocks
{
    public class BlockCreateBase : CreateBase<Block>
    {
        public Dictionary<string, string> BlockCatigoryItems { get; set; } = new Dictionary<string, string>();

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            BlockCatigoryItems =  await GetIndexData<BlockCategory>();

        }

    }
}
