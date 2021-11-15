using OA.Domin.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OA.WASM.Services.Logging
{
    public class ExceptionLogService : ServiceBase<ExceptionLog>
    {
        private readonly HttpClient HttpClient;

        public ExceptionLogService(HttpClient httpClient) : base(httpClient, nameof(ExceptionLog))
        {
            this.HttpClient = httpClient;
        }
    }
}
