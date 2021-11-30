using Microsoft.AspNetCore.Components;
using OA.Domin.DSA.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.Indexes.ChampionshipsRanking
{
    public partial class ChampionshipRankingForm : ComponentBase
    {

        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public ChampionshipRanking ChampionshipRanking { get; set; } = new ChampionshipRanking();

        public string Active { get; set; } = "";

        protected override void OnInitialized()
        {
            Active = (IsEdit) ? "active" : "";

        }

    }
}
