using LivrariaJabutiAPI.Domain.Models.DTOs.Authentication;
using LivrariaJabutiAPI.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LivrariaJabutiAPI.Web.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly IUserAuthService _userAuthService;
        public UserAuthController(IUserAuthService userAuthService)
        {
            _userAuthService = userAuthService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserAuthenticatedDTO),200)]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequestDTO registerRequest, CancellationToken ct = default)
        {
            var response = await _userAuthService.Register(registerRequest, ct);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserAuthenticatedDTO), 200)]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDTO loginRequest, CancellationToken ct = default)
        {
            var response = await _userAuthService.Login(loginRequest, ct);
            return Ok(response);
        }



    }
}
