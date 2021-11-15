using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.WASM.ErrorHandler
{
    interface IErrorHandler
    {
        event Func<Exception, Task> OnException;
        Task Trigger(Exception ex);
    }
}
