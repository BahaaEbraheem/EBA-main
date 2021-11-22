using OA.Domin.DSA.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OA.WASM.Services.DSA.Indexes
{
    public class ChampionshipRankingService : ServiceBase<ChampionshipRanking>
    {

        public ChampionshipRankingService(HttpClient client) : base(client, "ChampionshipRanking")
        {

        }

    }
}
