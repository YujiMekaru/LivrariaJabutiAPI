using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Domain.Models.DTOs.Book
{
    public class SaleInsertDTO
    {
        [Required]
        public int BookId { get; set; }
        public string Description { get; set; } = String.Empty;
        public float Amount { get; set; }
        public DateOnly SaleEndDate { get; set; }
    }
}
