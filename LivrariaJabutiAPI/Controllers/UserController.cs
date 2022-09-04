using LivrariaJabutiAPI.Domain.Models.DTOs.User;
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



        /// <summary>
        /// Gets the authenticated user details.
        /// </summary>
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

        /// <summary>
        /// Updates the authenticated user
        /// </summary>
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update(UserEditRequestDTO request, CancellationToken ct = default)
        {
            if (User.Identity == null)
                throw new Exception("Could not verify user Identity.");

            var id = User.Identity.Name;

            if (id == null)
                throw new Exception("Could not verify user Id");

            var response = await _userService.Update(int.Parse(id), request, ct);

            return Ok(response);
        }

        /// <summary>
        /// ADMIN - Gets all users.
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll(CancellationToken ct = default)
        {
            var response = await _userService.GetAll(ct);
            return Ok(response);
        }

        /// <summary>
        /// ADMIN - Gets a user by id.
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct = default)
        {
            var response = await _userService.GetDetailsById(id, ct);
            return Ok(response);
        }

        /// <summary>
        /// ADMIN - Updates a user by their id.
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, UserEditRequestDTO request, CancellationToken ct = default)
        {
            var response = await _userService.Update(id, request, ct);

            return Ok(response);
        }

        /// <summary>
        /// ADMIN - Deletes a user by their id.
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct = default)
        {
            await _userService.Delete(id, ct);
            return Ok();
        }
    }
}
