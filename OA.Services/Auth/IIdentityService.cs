using OA.Domain.Requests;
using OA.Domain.Responces;
using OA.Domin.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Services.Auth
{
    public interface IIdentityService
    {
        Task<AuthResult> RegisterAsync(RegisterRequest registerRequest);

        Task<AuthResult> LoginAsync(LoginRequest loginRequest);

        AuthResult RefreshToken(RefreshTokenRequest refreshToken);

        Task<AuthResult> RegisterRequest(RegisterRequest registerRequest);

        Task<AuthResult> CustomerRegister(CustomerRegisterRequest registerRequest);
    }
}
