using LivrariaJabutiAPI.Domain.Entities.Base;
using LivrariaJabutiAPI.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Domain.Entities.Carts
{
    public class Cart : Entity
    {
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = new User();
        public virtual IList<CartItem> CartItems { get; set; } = new List<CartItem>();
        public CartStatusEnum Status { get; set; }
    }
}
