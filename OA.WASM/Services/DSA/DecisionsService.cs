using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OA.WASM.Services.DSA
{
    public class DecisionsService : ServiceBase<Decision>
    {

        public DecisionsService(HttpClient client) : base(client, "Decisions")
        {

        }

    }
}
