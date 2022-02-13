using LivrariaJabutiAPI.Domain.Models.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Service.Interfaces
{
    public interface IBookService
    {
        Task<BookResponseDTO> GetById(int id, CancellationToken ct);
        Task<ICollection<BookResponseDTO>> GetAll(CancellationToken ct);
        Task<BookResponseDTO> Save(BookInsertDTO bookInsert, CancellationToken ct);
        Task Delete(int id, CancellationToken ct);
        Task<BookResponseDTO> Update(int id, BookUpdateDTO bookUpdate, CancellationToken ct);
    }
}
