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
        public Task<UserAuthenticatedDTO> Register(UserRegisterRequestDTO registerRequest, CancellationToken ct = default);
        public Task<UserAuthenticatedDTO> Login(UserLoginRequestDTO loginRequest, CancellationToken ct = default);
    }
}
