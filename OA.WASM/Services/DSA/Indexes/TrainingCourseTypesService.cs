using OA.Domin.DSA.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OA.WASM.Services.DSA.Indexes
{
    public class TrainingCourseTypesService : ServiceBase<TrainingCourseType>
    {

        public TrainingCourseTypesService(HttpClient client) : base(client, "TrainingCourseTypes")
        {

        }

    }
}
