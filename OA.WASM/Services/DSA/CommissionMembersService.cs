using OA.Domin.DSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OA.WASM.Services.DSA
{
    public class CommissionMembersService : ServiceBase<CommissionMembers>
    {

        public CommissionMembersService(HttpClient client) : base(client, "CommissionMembers")
        {

        }

    }
}
