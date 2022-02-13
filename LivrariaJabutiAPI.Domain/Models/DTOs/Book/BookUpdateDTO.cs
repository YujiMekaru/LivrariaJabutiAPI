using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Domain.Models.DTOs.Book
{
    public class BookUpdateDTO
    {
        public string? Title { get; set; }
        public float? Amount { get; set; }
        public string? Author { get; set; } 
        public string? Publisher { get; set; }
        public string? ImageUrl { get; set; } 
        public bool? OnSale { get; set; }
    }
}
