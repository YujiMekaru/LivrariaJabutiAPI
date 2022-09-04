using LivrariaJabutiAPI.Domain.Models.DTOs.Book;
using LivrariaJabutiAPI.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LivrariaJabutiAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSales(CancellationToken ct = default)
        {
            var response = await _saleService.GetAll(ct);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct = default)
        {
            var response = await _saleService.GetById(id, ct);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save([FromBody] SaleInsertDTO saleInsert, CancellationToken ct = default)
        {
            await _saleService.Save(saleInsert, ct);
            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct = default)
        {
            await _saleService.Delete(id, ct);
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public async Task<IActionResult> Update(SaleUpdateDTO updateBook, CancellationToken ct = default)
        {
            await _saleService.Update(updateBook, ct);
            return Ok();
        }
    }
}

