using LivrariaJabutiAPI.Domain.Models.DTOs.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Service.Interfaces
{
    public interface ICartService
    {
        Task InsertItem(int userId, InsertToCartDTO itemInsert, CancellationToken ct);
        Task Update(int userId, UpdateCartDTO updateCart, CancellationToken ct);
    }
}
