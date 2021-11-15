using OA.Domain.Requests;
using OA.Domain.Responces;
using OA.Domin.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Services.Auth
{
    public interface IAuthService
    {
        public Task<AuthResult> RegisterAsync(RegisterRequest registerRequest);
        public Task<AuthResult> LoginAsync(LoginRequest loginRequest);

        public Task<AuthResult> CustomerRegister(CustomerRegisterRequest registerRequest);

        public Task LogoutUserAsync();

        public Task<string> RefreshTokenAsync();

        public Task<AuthResult> RegisterRequest(RegisterRequest registerRequest);

    }
}
