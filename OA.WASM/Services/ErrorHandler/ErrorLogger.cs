using Microsoft.Extensions.Logging;
using OA.Domin.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace OA.WASM.ErrorHandler
{
    class ErrorLogger : ILogger
    {
        private readonly IErrorHandler errorHandler;
        public ErrorLogger(IErrorHandler errorHandler)
        {
            this.errorHandler = errorHandler;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new FakeScope();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= LogLevel.Error;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (logLevel < LogLevel.Error) return;

            var exceptionLog = new ExceptionLog
            {
                Message = $"Client Error : {exception.Message}",
                Path = exception.Source,
                StackTrace = exception.StackTrace
            };

            //httpClient.PostAsJsonAsync("Error/SaveClientError", exceptionLog);
            
            errorHandler.Trigger(exception);
        }
    }

    class FakeScope : IDisposable
    {
        public void Dispose()
        {

        }
    }
}
