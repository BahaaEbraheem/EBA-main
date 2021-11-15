using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OA.WASM.Services.DSA
{
    public class EventTranslationsService : ServiceBase<EventTranslation>
    {

        public EventTranslationsService(HttpClient client) : base(client, "EventTranslations")
        {

        }

    }
}
