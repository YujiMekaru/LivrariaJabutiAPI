﻿using LivrariaJabutiAPI.Domain.Entities.Users;
using LivrariaJabutiAPI.Domain.Models.DTOs.Authentication;
using LivrariaJabutiAPI.Infrastructure;
using LivrariaJabutiAPI.Service.Extensions;
using LivrariaJabutiAPI.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        private readonly ITokenService _tokenService;

        public UserAuthService(ApplicationDbContext ctx, ITokenService tokenService)
        {
            _ctx = ctx;
            _tokenService = tokenService;
        }

        public async Task<UserAuthenticatedDTO> Register(UserRegisterRequestDTO registerRequest, CancellationToken ct)
        {
            var newUser = new User
            {
                Name = registerRequest.Name,
                CPF = registerRequest.CPF.ToUpper(),
                Email = registerRequest.Email.ToLower(),
                BirthDate = registerRequest.BirthDate.ToDateOnly(),
                Password = registerRequest.Password.ToMD5(),
                Address = registerRequest.Address,
                Role = UserRoleEnum.Customer
            };

            if (await _ctx.Users.AnyAsync(u => u.CPF == newUser.CPF, ct))
                throw new Exception("CPF digitado já está em uso");

            if (await _ctx.Users.AnyAsync(u => u.Email == newUser.Email, ct))
                throw new Exception("Email digitado já está em uso");

            // TODO : VALIDATE FIELDS
            newUser.Validate();
            
            await _ctx.Users.AddAsync(newUser, ct);

            await _ctx.SaveChangesAsync(ct);

            return new UserAuthenticatedDTO
            {
                Token = _tokenService.GenerateToken(newUser)
            };
        }

        public async Task<UserAuthenticatedDTO> Login(UserLoginRequestDTO loginRequest, CancellationToken ct = default)
        {
            var hashPass = loginRequest.Password.ToMD5();
            var email = loginRequest.Email.ToUpper();
            var user = await _ctx.Users.FirstOrDefaultAsync(u => u.Email == loginRequest.Email && u.Password == hashPass, ct);
            
            if (user is null)
                throw new Exception("Usuário não encontrado ou senha inválida.");

            return new UserAuthenticatedDTO
            {
                Token = _tokenService.GenerateToken(user)
            };

        }


    }
}
