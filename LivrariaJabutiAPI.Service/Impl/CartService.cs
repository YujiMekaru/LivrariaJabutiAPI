using LivrariaJabutiAPI.Domain.Entities.Carts;
using LivrariaJabutiAPI.Domain.Entities.Users;
using LivrariaJabutiAPI.Domain.Models.DTOs.Cart;
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
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _ctx;

        public CartService(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public async Task InsertItem(int userId, InsertToCartDTO itemInsert, CancellationToken ct)
        {
            if (userId != itemInsert.UserId)
                throw new Exception("Não é possível alterar o carrinho de outro usuário.");

            var user = await _ctx.Users.Include(s => s.Carts).ThenInclude(c => c.CartItems).Where(u => u.Id == itemInsert.UserId).FirstOrDefaultAsync(ct);
            if (user == null)
                throw new Exception("Usuário não encontrado.");

            // Se nenhum carrinho ativo, criar um carrinho.
            if (!user.Carts.Any(c => c.Status == CartStatusEnum.Pending))
            {
                var cartToAdd = new Cart
                {
                    User = user,
                    Status = CartStatusEnum.Pending
                };
                await _ctx.Carts.AddAsync(cartToAdd);
                await _ctx.SaveChangesAsync();
            }

            var cart = user.Carts.Where(c => c.Status == CartStatusEnum.Pending).FirstOrDefault();

            var book = await _ctx.Books.Where(b => b.Id == itemInsert.BookId).FirstOrDefaultAsync(ct);
            if (book == null)
                throw new Exception("Livro não encontrado.");

            var cartItem = cart.CartItems.FirstOrDefault(c => c.Book.Id == itemInsert.BookId);

            if (cartItem != null)
            {
                cartItem.Qty += itemInsert.Qty;
            }
            else
            { 
                var cartItemToAdd = new CartItem
                {
                    Book = book,
                    Cart = cart,
                    Qty = itemInsert.Qty
                };
                await _ctx.CartItems.AddAsync(cartItemToAdd);
            }

            await _ctx.SaveChangesAsync();
        }

        public async Task Update(int userId, UpdateCartDTO updateCart, CancellationToken ct)
        {
            var cart = await _ctx.Carts.Include(c => c.CartItems).Include(c => c.User).FirstOrDefaultAsync(c => c.Id == updateCart.CartId, ct);

            if (cart == null)
                throw new Exception("Carrinho não encontrado.");

            if (cart.User.Id != userId)
                throw new Exception("Não é possível alterar o carrinho de outro usuário.");

            if (cart.Status != CartStatusEnum.Pending)
                throw new Exception("Não é possivel alterar um carrinho finalizado.");

            _ctx.CartItems.RemoveRange(cart.CartItems);
     
            if (updateCart.BooksOnCart != null)
            {
                IList<CartItem> toAdd = new List<CartItem>();
                foreach (var bookOrder in updateCart.BooksOnCart)
                {
                    var book = await _ctx.Books.FirstOrDefaultAsync(b => bookOrder.BookId == b.Id, ct);

                    if (book == null)
                        throw new Exception("Livro não encontrado.");

                    toAdd.Add(new CartItem
                    {
                        Book = book,
                        Qty = bookOrder.Qty,
                        Cart = cart
                    });
                }

                await _ctx.CartItems.AddRangeAsync(toAdd, ct);
            }

            await _ctx.SaveChangesAsync(ct);
        }

        public async Task FinishCart(int userId, int cartId, CancellationToken ct)
        {

        }
    }
}
