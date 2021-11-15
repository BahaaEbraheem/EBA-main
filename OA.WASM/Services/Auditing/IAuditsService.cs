using OA.Domin.Auditing;
using OA.Domin.Paging;
using OA.Domin.Requests;
using OA.Domin.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OA.Domin.Responces;

namespace OA.WASM.Services.Auditing
{
    public interface IAuditsService
    {

        Task<PagedResponse<Audit>> GetAudits(AuditSearchRequest auditSearchRequest, RequestParameters pagingParameters);

        Task TryReverseCahnge(Dictionary<string, object> OldData);

        Task TryRetriveDeleted();

    }
}
