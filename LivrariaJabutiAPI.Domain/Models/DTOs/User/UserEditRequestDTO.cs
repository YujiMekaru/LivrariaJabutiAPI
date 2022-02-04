using LivrariaJabutiAPI.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Domain.Models.DTOs.User
{
    public class UserEditRequestDTO
    {
        public string? Name { get; set; }
        public string? CPF { get; set; }
        public string? Email { get; set; }
        public string? BirthDate { get; set; }
        public string? Password { get; set; }
        public UserAddress? Address { get; set; }
    }
}
