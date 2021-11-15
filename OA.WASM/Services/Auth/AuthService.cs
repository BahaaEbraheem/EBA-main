using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using OA.Domain.Requests;
using OA.Domain.Responces;
using OA.Domin.Requests;
using OA.WASM.Services.JsonConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;

namespace OA.WASM.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient httpClient;
        private readonly string endpoint;
        private readonly IJsonConverter JsonConverter;
        private readonly ILocalStorageService localStorageService;
        private readonly AuthenticationStateProvider stateProvider;
        private readonly NavigationManager NavigationManager;

        public AuthService(HttpClient httpClient,
                           IJsonConverter jsonConverter,
                           ILocalStorageService localStorageService,
                           AuthenticationStateProvider stateProvider,                          
                           NavigationManager navigationManager,
                           string endpoint = "Auth")
        {
            this.httpClient = httpClient;
            this.endpoint = endpoint;
            this.JsonConverter = jsonConverter;
            this.localStorageService = localStorageService;
            this.stateProvider = stateProvider;
            this.NavigationManager = navigationManager;
        }

        public async Task<AuthResult> RegisterAsync(RegisterRequest registerRequest)
        {
            var response = await httpClient.PostAsJsonAsync($"{endpoint}/Register", registerRequest);
            var body = await response.Content.ReadAsStringAsync();

            var authResult = JsonConverter.DeserializeObject<AuthResult>(body);

            return authResult;
        }

        public async Task<AuthResult> CustomerRegister(CustomerRegisterRequest registerRequest)
        {
            var response = await httpClient.PostAsJsonAsync($"{endpoint}/CustomerRegister", registerRequest);
            var body = await response.Content.ReadAsStringAsync();

            var authResult = JsonConverter.DeserializeObject<AuthResult>(body);

            return authResult;
        }

        public async Task<AuthResult> LoginAsync(LoginRequest loginRequest)
        {
            var response = await httpClient.PostAsJsonAsync($"{endpoint}/Login", loginRequest);
            var body = await response.Content.ReadAsStringAsync();

            var authResult = JsonConverter.DeserializeObject<AuthResult>(body);

            return authResult;
        }

        public async Task<string> RefreshTokenAsync()
        {
            var request = new RefreshTokenRequest()
            {
                Token = await localStorageService.GetItemAsync<string>("AccessToken"),
                RefreshToken = await localStorageService.GetItemAsync<string>("RefreshToken")
            };

            var response = await httpClient.PostAsJsonAsync($"{endpoint}/Refresh", request);

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException("Something went wrong during the refresh token action");

            var body = await response.Content.ReadAsStringAsync();

            var authResult = JsonConverter.DeserializeObject<AuthResult>(body);

            if (!authResult.Successed)
            {
                await LogoutUserAsync();

                return "";
            }

            await localStorageService.SetItemAsync("AccessToken", authResult.Token);
            await localStorageService.SetItemAsync("RefreshToken", authResult.RefreshToken);

            await stateProvider.GetAuthenticationStateAsync();

            return authResult.Token;

        }

        public async Task LogoutUserAsync()
        {
            await localStorageService.RemoveItemAsync("AccessToken");
            await localStorageService.RemoveItemAsync("RefreshToken");
            await stateProvider.GetAuthenticationStateAsync();

            NavigationManager.NavigateTo("/auth/login", true);
        }

        public async Task<AuthResult> RegisterRequest(RegisterRequest registerRequest)
        {
            var response = await httpClient.PostAsJsonAsync($"{endpoint}/RegisterRequest", registerRequest);
            var body = await response.Content.ReadAsStringAsync();

            var authResult = JsonConverter.DeserializeObject<AuthResult>(body);

            return authResult;
        }
    }
}
