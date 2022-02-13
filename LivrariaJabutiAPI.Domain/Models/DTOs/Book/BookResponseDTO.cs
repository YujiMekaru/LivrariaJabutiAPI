using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Domain.Models.DTOs.Book
{
    public class BookResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public float Amount { get; set; }
        public string Author { get; set; } = String.Empty;
        public string Publisher { get; set; } = String.Empty;
        public string ImageUrl { get; set; } = String.Empty;
        public bool OnSale { get; set; } = false;
    }
}
