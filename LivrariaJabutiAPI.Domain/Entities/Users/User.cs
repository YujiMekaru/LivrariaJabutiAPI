using LivrariaJabutiAPI.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Domain.Entities.Users
{
    public class User : Entity
    {
        [Column(TypeName = "varchar(255)"), Required]
        public string? Name { get; set; }
        [Column(TypeName = "varchar(255)"), Required]
        public string? CPF { get; set; }
        [Column(TypeName = "varchar(255)"), Required]
        public string? Email { get; set; }
        [Required]
        public DateOnly? BirthDate { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public UserAddress? Address { get; set; }
    }
}
