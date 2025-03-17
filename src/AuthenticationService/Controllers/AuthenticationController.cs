using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AuthenticationService.Services;
using AuthenticationService.Models;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.Login(request.Email, request.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new { Token = token });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
        {
            await _authService.Logout(request.Token);
            return Ok();
        }
    }
}
