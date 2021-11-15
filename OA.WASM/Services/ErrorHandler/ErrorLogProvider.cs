using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace OA.WASM.ErrorHandler
{
    class ErrorLogProvider : ILoggerProvider
    {
        IErrorHandler errorHandler;
        public ErrorLogProvider(IErrorHandler errorHandler)
        {
            this.errorHandler = errorHandler;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new ErrorLogger(errorHandler);
        }

        public void Dispose()
        {

        }
    }
}
