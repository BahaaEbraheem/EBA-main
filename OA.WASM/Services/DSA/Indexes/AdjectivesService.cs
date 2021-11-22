using OA.Domin.DSA.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OA.WASM.Services.DSA.Indexes
{
    public class AdjectivesService : ServiceBase<Adjective>
    {

        public AdjectivesService(HttpClient client) : base(client, "Adjectives")
        {

        }

    }
}
