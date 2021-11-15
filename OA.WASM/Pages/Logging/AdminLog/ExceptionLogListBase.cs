using OA.Domin.Logging;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.Logging.AdminLog
{
    public class ExceptionLogListBase : ListBase<ExceptionLog>
    {
        public string CurrntDetails = "";

        public void ShowDetails(string details)
        {
            CurrntDetails = details;
        }
    }
}
