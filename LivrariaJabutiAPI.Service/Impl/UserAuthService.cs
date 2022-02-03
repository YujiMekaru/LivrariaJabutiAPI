﻿using LivrariaJabutiAPI.Domain.Entities.Users;
using LivrariaJabutiAPI.Domain.Models.DTOs.Authentication;
using LivrariaJabutiAPI.Infrastructure;
using LivrariaJabutiAPI.Service.Extensions;
using LivrariaJabutiAPI.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Service.Impl
{
    public class UserAuthService : IUserAuthService
    {
        private readonly ApplicationDbContext _ctx;

        public UserAuthService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Register(UserRegisterRequestDTO registerRequest, CancellationToken ct)
        {
            var newUser = new User
            {
                Name = registerRequest.Name,
                CPF = registerRequest.CPF?.ToUpper(),
                Email = registerRequest.Email?.ToLower(),
                BirthDate = registerRequest.BirthDate.ToDateOnly(),
                Password = registerRequest.Password.ToMD5(),
                Address = registerRequest.Address
            };

            if (_ctx.Users.Any(u => u.CPF == newUser.CPF))
                throw new Exception("CPF digitado já está em uso");

            if (_ctx.Users.Any(u => u.Email == newUser.Email))
                throw new Exception("Email digitado já está em uso");

            // TODO : VALIDATE FIELDS
            
            await _ctx.Users.AddAsync(newUser, ct);

            await _ctx.SaveChangesAsync(ct);

            // TODO : RETURN USER DETAILS
        }

        public async Task<UserResponseDTO> Login(UserLoginRequestDTO loginRequest, CancellationToken ct = default)
        {
            var hashPass = loginRequest.Password.ToMD5();
            var email = loginRequest.Email.ToUpper();
            var user = _ctx.Users.FirstOrDefault(u => u.Email == loginRequest.Email && u.Password == hashPass);
            
            if (user is null)
                throw new Exception("Usuário não encontrado ou senha inválida.");

            return new UserResponseDTO
            {
                Email = user.Email,
                Name = user.Name
            };

        }


    }
}