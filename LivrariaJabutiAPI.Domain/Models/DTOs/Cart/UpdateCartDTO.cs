using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Domain.Models.DTOs.Cart
{
    public class UpdateCartDTO
    {
        public int CartId { get; set; }
        public IList<BookOnCart>? BooksOnCart { get; set; }
    }

    public class BookOnCart
    {
        public int BookId { get; set; }
        public int Qty { get; set; }
    }
}
