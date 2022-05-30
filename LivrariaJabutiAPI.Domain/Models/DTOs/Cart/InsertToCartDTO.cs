using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Domain.Models.DTOs.Cart
{
    public class InsertToCartDTO
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Qty { get; set; }
    }
}
