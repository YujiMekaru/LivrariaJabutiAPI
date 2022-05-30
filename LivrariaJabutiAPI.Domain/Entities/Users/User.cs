using LivrariaJabutiAPI.Domain.Entities.Base;
using LivrariaJabutiAPI.Domain.Entities.Carts;
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
        public string Name { get; set; } = String.Empty;
        [Column(TypeName = "varchar(255)"), Required]
        public string CPF { get; set; } = String.Empty;
        [Column(TypeName = "varchar(255)"), Required]
        public string Email { get; set; } = String.Empty;
        [Required]
        public DateOnly BirthDate { get; set; }
        [Required]
        public string Password { get; set; } = String.Empty;
        [Required]
        public UserAddress Address { get; set; } = new UserAddress();
        [Required]
        public UserRoleEnum Role { get; set; } = UserRoleEnum.Customer;
        public virtual IList<Cart> Carts { get; set; } = new List<Cart>();
    }
}
