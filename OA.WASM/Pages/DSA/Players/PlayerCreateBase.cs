using OA.Domin.DSA;
using OA.Domin.DSA.Indexes;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.Players
{
    public class PlayerCreateBase : CreateBase<Player>
    {
        public Dictionary<string, string> AdjectiveItems { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> AgeCategoryItems { get; set; } = new Dictionary<string, string>();

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            AdjectiveItems = await GetIndexData<Adjective>();
            AgeCategoryItems = await GetIndexData<AgeCategory>();
        }

    }
}
