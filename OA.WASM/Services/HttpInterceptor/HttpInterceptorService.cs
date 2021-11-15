using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using OA.Domin.Responces;
using OA.WASM.Services.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Reflection;
using System.Threading.Tasks;
using Toolbelt.Blazor;

namespace OA.WASM.Services
{
    public class HttpInterceptorService
    {
        private readonly HttpClientInterceptor clientInterceptor;
        private readonly RefreshTokenService refreshTokenService;
        private readonly NavigationManager NavigationManager;
        private readonly IJSRuntime JSRT;

        public HttpInterceptorService(HttpClientInterceptor clientInterceptor, RefreshTokenService refreshTokenService, NavigationManager navigationManager, IJSRuntime jsrt)
        {
            this.clientInterceptor = clientInterceptor;
            this.refreshTokenService = refreshTokenService;
            this.NavigationManager = navigationManager;
            this.JSRT = jsrt;
        }

        public void RegisterEvents() 
        {              
            clientInterceptor.BeforeSend += InterceptBeforeHttp;
            clientInterceptor.AfterSend += InterceptResponse;
        }

        public async void InterceptBeforeHttp(object sender, HttpClientInterceptorEventArgs e)
        {
            var path = e.Request.RequestUri.AbsolutePath;

            if (!path.Contains("Auth"))
            {
                await refreshTokenService.TryRefreshToken();
                //Task.CurrentId.
            }
        }

        public async void InterceptResponse(object sender, HttpClientInterceptorEventArgs e)
        {
            if (!e.Response.IsSuccessStatusCode)
            {
                string message = string.Empty;
                var statusCode = e.Response.StatusCode;
                switch (statusCode)
                {
                    case HttpStatusCode.NotFound:
                    case HttpStatusCode.MethodNotAllowed:
                        NavigationManager.NavigateTo("/404");
                        message = "Endpoint not found";
                        break;
                    case HttpStatusCode.Unauthorized:
                        NavigationManager.NavigateTo("/403");
                        message = "You Are Not Authorized To Do This Operation";
                        break;
                    case HttpStatusCode.InternalServerError:
                        //NavigationManager.NavigateTo("/500");
                        message = "Unexpected Error (Call The System Adminstrator)";
                        break;
                    case HttpStatusCode.BadRequest:
                        //NavigationManager.NavigateTo("/500");
                        message = "Unexpected Bad Request (Call The System Adminstrator)";
                        break;
                }
                await JSRT.InvokeVoidAsync("Toast", message, "error", 10000);
                throw new ApplicationException(message);
            }
        }

        public void DisposeEvents() { 
            clientInterceptor.BeforeSend -= InterceptBeforeHttp;
            clientInterceptor.AfterSend -= InterceptResponse;
        }

    }
}
