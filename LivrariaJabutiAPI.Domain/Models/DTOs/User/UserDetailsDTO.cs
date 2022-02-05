using LivrariaJabutiAPI.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Domain.Models.DTOs.User
{
    public class UserDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string CPF { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string BirthDate { get; set; } = String.Empty;
        public UserAddress Address { get; set; } = new UserAddress();
        public string Role { get; set; } = String.Empty;
    }
}
