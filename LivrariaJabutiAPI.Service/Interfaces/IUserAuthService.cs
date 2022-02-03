using LivrariaJabutiAPI.Domain.Models.DTOs.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Service.Interfaces
{
    public interface IUserAuthService
    {
        public Task Register(UserRegisterRequestDTO registerRequest, CancellationToken ct = default);
    }
}
