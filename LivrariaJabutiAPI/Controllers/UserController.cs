using LivrariaJabutiAPI.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaJabutiAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll(CancellationToken ct = default)
        {
            var response = await _userService.GetAll(ct);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct = default)
        {
            var response = await _userService.GetDetailsById(id, ct);
            return Ok(response);
        }

        [HttpGet]
        [Route("details")]
        [Authorize]
        public async Task<IActionResult> GetUserDetails(CancellationToken ct = default)
        {
            if (User.Identity == null)
                throw new Exception("Could not verify user Identity.");

            var id = User.Identity.Name;

            if (id == null)
                throw new Exception("Could not verify user Id");

            var response = await _userService.GetDetailsById(int.Parse(id), ct);

            return Ok(response);
        }
    }
}
