using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OA.Domain.Requests;
using OA.Domain.Responces;
using OA.Domin.Requests;
using OA.Services.Auth;

namespace OA_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService identityService;

        public AuthController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest registerRequest)
        {
            var authResult = await identityService.RegisterAsync(registerRequest);

            if (!authResult.Successed)
            {
                return Ok(authResult);
            }

            return Ok(authResult);
        }

        [HttpPost("CustomerRegister")]
        public async Task<IActionResult> CustomerRegister(CustomerRegisterRequest customerRegisterRequest)
        {
            var authResult = await identityService.CustomerRegister(customerRegisterRequest);

            return Ok(authResult);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest registerRequest)
        {

            var authResult = await identityService.LoginAsync(registerRequest);

            if (!authResult.Successed)
            {
                return Ok(authResult);
            }
            return Ok(authResult);
        }

        [HttpPost("Refresh")]
        public IActionResult RefreshToken([FromBody] RefreshTokenRequest refreshTokenRequest)
        {

            var authResult = identityService.RefreshToken(refreshTokenRequest);

            if (!authResult.Successed)
            {
                //if (authResult.Errors.Contains("Refresh Token Expired"))
                //    return Ok(authResult);

                return Ok(authResult);
            }

            return Ok(authResult);

        }

        [HttpPost("RegisterRequest")]
        public async Task<IActionResult> RegisterRequest(RegisterRequest registerRequest)
        {
            var authResult = await identityService.RegisterRequest(registerRequest);

            return Ok(authResult);

        }


    }
}
