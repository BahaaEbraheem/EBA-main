using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Services.Auth
{
    public class RefreshTokenService
    {
        private readonly AuthenticationStateProvider stateProvider;
        private readonly IAuthService authService;
        public RefreshTokenService(AuthenticationStateProvider stateProvider, IAuthService authService)
        {
            this.stateProvider = stateProvider;
            this.authService = authService;
        }

        public async Task<string> TryRefreshToken()
        {
            var state = await stateProvider.GetAuthenticationStateAsync();

            var user = state.User;
            if(user == null || user.Claims.Count() == 0) return string.Empty;

            var exp = user.FindFirst(c => c.Type.Equals("exp")).Value;
            var expTime = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(exp));

            var timeUtc = DateTime.UtcNow;

            var diff = expTime - timeUtc;

            if (diff.TotalMinutes <= 2)
                return await authService.RefreshTokenAsync();

            return string.Empty;
        }

    }
}
