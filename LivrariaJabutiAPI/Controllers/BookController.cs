using LivrariaJabutiAPI.Domain.Models.DTOs.Book;
using LivrariaJabutiAPI.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaJabutiAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetBooks(CancellationToken ct = default)
        {
            var response = await _bookService.GetAll(ct);
            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct = default)
        {
            var response = await _bookService.GetById(id, ct);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Save([FromForm]IFormFile file, [FromQuery]BookInsertDTO insertBook, CancellationToken ct = default)
        {
            var response = await _bookService.Save(file, insertBook, ct);
            return Ok(response);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct = default)
        {
            await _bookService.Delete(id, ct);
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public async Task<IActionResult> Update(BookUpdateDTO updateBook, int id, CancellationToken ct = default)
        {
            var response = await _bookService.Update(id, updateBook, ct);
            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("{id}/update-image")]
        public async Task<IActionResult> UpdateImage(IFormFile file, int id, CancellationToken ct = default)
        {
            var response = await _bookService.UpdateImage(id, file, ct);
            return Ok(response);
        }
    }
}
