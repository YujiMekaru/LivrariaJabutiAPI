using LivrariaJabutiAPI.Domain.Entities.Base;
using LivrariaJabutiAPI.Domain.Entities.Books;
using LivrariaJabutiAPI.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Domain.Entities.Carts
{
    public class CartItem : Entity
    {
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; }
        public int Qty { get; set; } = 0;
    }
}
