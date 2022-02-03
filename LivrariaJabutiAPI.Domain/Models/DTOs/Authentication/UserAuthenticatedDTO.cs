using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Domain.Models.DTOs.Authentication
{
    public class UserAuthenticatedDTO
    {
        public string Token { get; set; } = String.Empty;
    }
}
