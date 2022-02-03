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
        public Task<UserResponseDTO> Register(UserRegisterRequestDTO registerRequest, CancellationToken ct = default);
        public Task<UserResponseDTO> Login(UserLoginRequestDTO loginRequest, CancellationToken ct = default);
    }
}
