using OA.Domin.DSA;
using OA.Domin.DSA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OA.WASM.Services.DSA
{
    public class AdministrationBoardsService : ServiceBase<AdministrationBoard>
    {
        public AdministrationBoardsService(HttpClient client) : base(client, "AdministrationBoards")
        {

        }

    }
}
