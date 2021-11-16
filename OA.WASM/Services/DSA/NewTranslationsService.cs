using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OA.WASM.Services.DSA
{
    public class NewTranslationsService : ServiceBase<NewTranslation>
    {

        public NewTranslationsService(HttpClient client) : base(client, "NewTranslations")
        {

        }

    }
}
