using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.WASM.ErrorHandler
{
    class DefaultErrorHandler : IErrorHandler
    {
        public event Func<Exception, Task> OnException;

        public async Task Trigger(Exception ex)
        {
            if (OnException != null) await OnException(ex);
        }
    }
}
