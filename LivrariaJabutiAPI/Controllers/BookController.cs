using LivrariaJabutiAPI.Domain.Models.DTOs.Book;
using LivrariaJabutiAPI.Service.Interfaces;
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
        public async Task<IActionResult> GetBooks(CancellationToken ct = default)
        {
            var response = await _bookService.GetAll(ct);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct = default)
        {
            var response = await _bookService.GetById(id, ct);
            return Ok(response);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Save([FromForm]IFormFile file, [FromForm]BookInsertDTO insertBook, CancellationToken ct = default)
        {
            var response = await _bookService.Save(file, insertBook, ct);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct = default)
        {
            await _bookService.Delete(id, ct);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(BookUpdateDTO updateBook, int id, CancellationToken ct = default)
        {
            var response = await _bookService.Update(id, updateBook, ct);
            return Ok(response);
        }
    }
}
