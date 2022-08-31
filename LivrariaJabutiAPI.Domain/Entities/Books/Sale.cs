using LivrariaJabutiAPI.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Domain.Entities.Books
{
    public class Sale : Entity
    {
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
        public string Description { get; set; } = String.Empty;
        public float Amount { get; set; }
        public DateOnly SaleEndDate { get; set; }
    }
}
