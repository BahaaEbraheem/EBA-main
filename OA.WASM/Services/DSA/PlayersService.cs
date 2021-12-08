using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OA.WASM.Services.DSA
{
    public class PlayersService : ServiceBase<Player>
    {

        public PlayersService(HttpClient client) : base(client, "Players")
        {

        }

    }
}
