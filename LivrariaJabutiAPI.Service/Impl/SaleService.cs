using AutoMapper;
using LivrariaJabutiAPI.Domain.Entities.Book;
using LivrariaJabutiAPI.Domain.Models.DTOs.Book;
using LivrariaJabutiAPI.Infrastructure;
using LivrariaJabutiAPI.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Service.Impl
{
    public class SaleService : ISaleService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;
        public SaleService(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Sale>> GetAll(CancellationToken ct)
        {
            DateOnly dateOnlyNow = DateOnly.FromDateTime(DateTime.Now);
            return await _ctx.Sales.Include(s => s.Book).Where(s => s.SaleEndDate >= dateOnlyNow).ToListAsync(ct);
        }

        public async Task<Sale> GetById(int id, CancellationToken ct)
        {
            var sale = await _ctx.Sales.Include(s => s.Book).Where(s => s.Id == id).FirstOrDefaultAsync(ct);

            if (sale == null)
                throw new Exception("Sale not found");

            return sale;
        }

        public async Task Save(SaleInsertDTO saleInsert, CancellationToken ct)
        {
            var sale = _mapper.Map<Sale>(saleInsert);
            
            var book = await _ctx.Books.Where(b => b.Id == saleInsert.BookId).FirstOrDefaultAsync(ct);
           
            if (book == null)
                throw new Exception("Book not found");

            await _ctx.Sales.AddAsync(sale, ct);

            book.OnSale = true;

            await _ctx.SaveChangesAsync(ct);
        }

        public async Task Delete(int id, CancellationToken ct)
        {
            var sale = await _ctx.Sales.Where(s => s.Id == id).FirstOrDefaultAsync(ct);

            if (sale == null)
                throw new Exception("Sale not found");

            var book = await _ctx.Books.Where(b => b.Id == sale.BookId).FirstOrDefaultAsync(ct);

            if (book == null)
                throw new Exception("Book not found");

            _ctx.Sales.Remove(sale);

            book.OnSale = false;

            await _ctx.SaveChangesAsync(ct);
        }

        public async Task Update(SaleUpdateDTO saleUpdate, CancellationToken ct)
        {
            var sale = await _ctx.Sales.Where(s => s.Id == saleUpdate.Id).FirstOrDefaultAsync(ct);

            if (sale == null)
                throw new Exception("Sale not found");

            if (saleUpdate.BookId.HasValue)
                sale.BookId = saleUpdate.BookId.Value;

            if (saleUpdate.Description != String.Empty)
                sale.Description = saleUpdate.Description;

            if (saleUpdate.Amount.HasValue)
                sale.Amount = saleUpdate.Amount.Value;

            if (saleUpdate.SaleEndDate.HasValue)
                sale.SaleEndDate = saleUpdate.SaleEndDate.Value;

            await _ctx.SaveChangesAsync(ct);
        }
    }
}
