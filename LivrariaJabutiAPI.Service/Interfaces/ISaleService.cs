using LivrariaJabutiAPI.Domain.Entities.Books;
using LivrariaJabutiAPI.Domain.Models.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Service.Interfaces
{
    public interface ISaleService
    {
        Task<IEnumerable<Sale>> GetAll(CancellationToken ct);
        Task<Sale> GetById(int id, CancellationToken ct);
        Task Save(SaleInsertDTO saleInsert, CancellationToken ct);
        Task Update(SaleUpdateDTO saleUpdate, CancellationToken ct);
        Task Delete(int id, CancellationToken ct);
    }
}
