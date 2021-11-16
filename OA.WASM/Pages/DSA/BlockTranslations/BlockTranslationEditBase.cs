using OA.Domin.DSA;
using OA.Domin.DSA.Indexes;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.BlockTranslations
{
    public class BlockTranslationEditBase : EditBase<BlockTranslation>
    {

        public Dictionary<string, string> BlockItems { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> LanguageItems { get; set; } = new Dictionary<string, string>();
        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            BlockItems = await GetIndexData<Block>();
            LanguageItems = await GetIndexData<Language>();

        }

    }
}
