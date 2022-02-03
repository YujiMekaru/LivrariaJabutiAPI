using LivrariaJabutiAPI.Domain.Models.DTOs.Authentication;
using LivrariaJabutiAPI.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaJabutiAPI.Web.Controllers
{
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
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequestDTO registerRequest, CancellationToken ct = default)
        {
            await _userAuthService.Register(registerRequest, ct);
            return Ok();
        }



    }
}
