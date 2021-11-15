using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using OA.Domin.Auditing;
using OA.Domin.Paging;
using OA.Domin.RequestFeatures;
using OA.Domin.Requests;
using OA.Domin.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OA.WASM.Services.Auditing
{
    public class AuditsService : IAuditsService
    {
        private readonly HttpClient httpClient;
        private string endpoint = "api/Audits";

        public AuditsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;

        }

        public async Task<PagedResponse<Audit>> GetAudits(AuditSearchRequest auditSearchRequest, RequestParameters pagingParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = pagingParameters.PageNumber.ToString(),
            };

            var response = await httpClient.PostAsJsonAsync(QueryHelpers.AddQueryString($"{endpoint}/GetAudits", queryStringParam), auditSearchRequest);

            var content = await response.Content.ReadAsStringAsync();

            var pagedResponce = new PagedResponse<Audit>
            {
                Items = JsonConvert.DeserializeObject<List<Audit>>(content),
                PagingData = JsonConvert.DeserializeObject<PagingMetaData>(response.Headers.GetValues("X-Pagination").First())
            };

            return pagedResponce;

        }

        public Task TryRetriveDeleted()
        {
            throw new NotImplementedException();
        }

        public Task TryReverseCahnge(Dictionary<string, object> OldData)
        {
            throw new NotImplementedException();
        }
    }
}
