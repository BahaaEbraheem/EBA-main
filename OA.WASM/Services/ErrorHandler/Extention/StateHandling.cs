using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OA.WASM.ErrorHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Services.ErrorHandler.Extention
{
    public static class StateHandling
    {

        public static ILoggingBuilder ErrorLogger(this ILoggingBuilder builder)
        {
            builder.Services.AddSingleton<ILoggerProvider, ErrorLogProvider>();
            return builder;
        }

        public static IServiceCollection AddStateManagement(this IServiceCollection services)
        {
            services.AddSingleton<IErrorHandler, DefaultErrorHandler>();

            services.AddLogging(builder => builder.ErrorLogger());

            return services;

        }

    }
}
