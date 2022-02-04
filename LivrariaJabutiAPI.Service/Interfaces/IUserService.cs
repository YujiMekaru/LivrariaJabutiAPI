using LivrariaJabutiAPI.Domain.Entities.Users;
using LivrariaJabutiAPI.Domain.Models.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Service.Interfaces
{
    public interface IUserService
    {
        public Task<ICollection<UserResponseDTO>> GetAll(CancellationToken ct = default);
        public Task<UserDetailsDTO> GetDetailsById(int id, CancellationToken ct = default);
    }
}
