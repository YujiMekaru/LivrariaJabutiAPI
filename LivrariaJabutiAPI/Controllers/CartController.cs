using LivrariaJabutiAPI.Domain.Models.DTOs.Cart;
using LivrariaJabutiAPI.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaJabutiAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> InsertItem([FromBody] InsertToCartDTO itemInsert, CancellationToken ct = default)
        {
            if (HttpContext.User.Identity == null)
                throw new Exception("Usuário não encontrado");
            var userId = int.Parse(HttpContext.User.Identity.Name);

            await _cartService.InsertItem(userId, itemInsert, ct);
            return Ok();
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateCartDTO updateCart, CancellationToken ct = default)
        {
            if (HttpContext.User.Identity == null)
                throw new Exception("Usuário não encontrado");
            var userId = int.Parse(HttpContext.User.Identity.Name);

            await _cartService.Update(userId, updateCart, ct);
            return Ok();
        }
    }
}
