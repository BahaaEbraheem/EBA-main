using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using OA.Domin.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace OA.WASM.Services.Auth
{
    public class LocalAuthenticationStateProvider : AuthenticationStateProvider
    {
        public ILocalStorageService LocalStorageService { get; set; }
        public HttpClient HttpClient { get; set; }

        public LocalAuthenticationStateProvider(ILocalStorageService localStorageService, HttpClient httpClient)
        {
            LocalStorageService = localStorageService;
            HttpClient = httpClient;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            AuthenticationState state;
            if (await LocalStorageService.ContainKeyAsync("AccessToken"))
            {
                var token = await LocalStorageService.GetItemAsync<string>("AccessToken");
                var claims = JwtParser.ParseClaimsFromJwt(token);
                var identity = new ClaimsIdentity(claims, "JwtBearer");
                var principal = new ClaimsPrincipal(identity);

                state = new AuthenticationState(principal);
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            }
            else
            {
                state = new AuthenticationState(new ClaimsPrincipal());
                HttpClient.DefaultRequestHeaders.Authorization = null;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;

        }

        public async Task<ClaimsPrincipal> GetCurrentUserAsync()
        {
            if (await LocalStorageService.ContainKeyAsync("AccessToken"))
            {
                var token = await LocalStorageService.GetItemAsync<string>("AccessToken");
                var claims = JwtParser.ParseClaimsFromJwt(token);
                var identity = new ClaimsIdentity(claims, "JwtBearer");
                var principal = new ClaimsPrincipal(identity);


                return principal;

            }

            return null;
        }

    }
}
