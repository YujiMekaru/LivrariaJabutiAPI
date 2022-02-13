using AutoMapper;
using LivrariaJabutiAPI.Domain.Entities.Book;
using LivrariaJabutiAPI.Domain.Models.DTOs.Book;
using LivrariaJabutiAPI.Infrastructure;
using LivrariaJabutiAPI.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Service.Impl
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;
        private readonly IFileStoreService _fileService;

        public BookService(ApplicationDbContext ctx, IMapper mapper, IFileStoreService fileService)
        {
            _ctx = ctx;
            _mapper = mapper;
            _fileService = fileService;
         }

        public async Task<ICollection<BookResponseDTO>> GetAll(CancellationToken ct)
        {
            var response = await _ctx.Books.Select(x => new BookResponseDTO
            {
                Id = x.Id,
                Title = x.Title,
                Amount = x.Amount,
                Author = x.Author,
                Publisher = x.Publisher,
                ImageUrl = x.ImageUrl
            }).ToListAsync(ct);

            return response;
        }

        public async Task<BookResponseDTO> GetById(int id, CancellationToken ct)
        {
            var book = await GetBook(id, ct);

            var model = _mapper.Map<BookResponseDTO>(book);

            return model;
        }

        public async Task<BookResponseDTO> Save(IFormFile file, BookInsertDTO bookInsert, CancellationToken ct)
        {
            var storedFile = await _fileService.StoreDocumentAsync(file, ct);
            
            var book = _mapper.Map<Book>(bookInsert);
            book.ImageUrl = storedFile.DocumentUrl;

            await _ctx.Books.AddAsync(book, ct);
            await _ctx.SaveChangesAsync(ct);

            return await GetById(book.Id, ct);
        }

        public async Task Delete(int id, CancellationToken ct)
        {
            var book = await GetBook(id, ct);

            _ctx.Books.Remove(book);
            await _ctx.SaveChangesAsync(ct);
        }

        public async Task<BookResponseDTO> Update(int id, BookUpdateDTO bookUpdate, CancellationToken ct)
        {
            var book = await GetBook(id, ct);

            if (bookUpdate.Title != null)
                book.Title = bookUpdate.Title;

            if (bookUpdate.Author != null)
                book.Author = bookUpdate.Author;

            if (bookUpdate.Amount != null)
                book.Amount = bookUpdate.Amount.Value;

            if (bookUpdate.Publisher != null)
                book.Publisher = bookUpdate.Publisher;

            if (bookUpdate.ImageUrl != null)
                book.ImageUrl = bookUpdate.ImageUrl;

            if (bookUpdate.OnSale != null)
                book.OnSale = bookUpdate.OnSale.Value;

            await _ctx.SaveChangesAsync(ct);

            return _mapper.Map<BookResponseDTO>(book);

        }

        private async Task<Book> GetBook(int id, CancellationToken ct)
        {
            var book = await _ctx.Books.FirstOrDefaultAsync(b => b.Id == id, ct);

            if (book == null)
                throw new Exception("Book not found");

            return book;
        }
    }
}
