using LivrariaJabutiAPI.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Domain.Entities.Book
{
    public class Book : Entity
    {
        [Column(TypeName = "varchar(255)"), Required]
        public string Title { get; set; } = String.Empty;
        [Required]
        public float Amount { get; set; } = 0;
        [Column(TypeName = "varchar(255)"), Required]
        public string Author { get; set; } = String.Empty;
        [Column(TypeName = "varchar(255)"), Required]
        public string Publisher { get; set; } = String.Empty;
        [Column(TypeName = "varchar(255)"), Required]
        public string ImageUrl { get; set; } = String.Empty;
        public bool OnSale { get; set; } = false;
    }
}
