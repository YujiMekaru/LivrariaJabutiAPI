using LivrariaJabutiAPI.Domain.Entities.Users;
using LivrariaJabutiAPI.Domain.Models.DTOs.User;
using LivrariaJabutiAPI.Infrastructure;
using LivrariaJabutiAPI.Service.Extensions;
using LivrariaJabutiAPI.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Service.Impl
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _ctx;

        public UserService (ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<ICollection<UserResponseDTO>> GetAll(CancellationToken ct)
        {
            var response = await _ctx.Users.Select(x => new UserResponseDTO
            {
                Id = x.Id,
                Name = x.Name,
                CPF = x.CPF,
                Email = x.Email,
                BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                Role = x.Role.ToString(),
            }).ToListAsync(ct);

            return response;
        }

        public async Task<UserDetailsDTO> GetDetailsById(int id, CancellationToken ct)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(u => u.Id == id, ct);

            if (user == null)
                throw new Exception("User not found");

            return new UserDetailsDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                CPF = user.CPF,
                BirthDate = user.BirthDate.ToString("dd/MM/yyyy"),
                Role = user.Role.ToString(),
                Address = user.Address
            };
        }

        public async Task<UserDetailsDTO> Update(int id,UserEditRequestDTO request, CancellationToken ct)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(u => u.Id == id, ct);

            if (user == null)
                throw new Exception("User not found");

            if (request.Name != null)
                user.Name = request.Name;

            if (request.Email != null)
                user.Email = request.Email;

            if (request.CPF != null)
                user.CPF = request.CPF;

            if (request.BirthDate != null)
                user.BirthDate = request.BirthDate.ToDateOnly();

            if (request.Address != null)
                user.Address = request.Address;

            if (request.Password != null)
                user.Password = request.Password.ToMD5();

            await _ctx.SaveChangesAsync(ct);

            return await GetDetailsById(user.Id, ct);
        }
        public async Task Delete(int id, CancellationToken ct = default)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(u => u.Id == id, ct);

            if (user == null)
                throw new Exception("User not found");

            _ctx.Remove(user);
            await _ctx.SaveChangesAsync(ct);
        }

    }
}
