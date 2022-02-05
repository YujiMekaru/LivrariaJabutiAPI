﻿using LivrariaJabutiAPI.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Service.Extensions
{
    public static class UserExtensions
    {
        public static void Validate(this User user)
        {
            if (user == null)
                throw new Exception("Invalid User");
            
            if (user.Name == "" || user.Name == String.Empty)
                throw new Exception("Invalid Name");

            var validEmailRegex = new Regex(@"^[a - zA - Z0 - 9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$",RegexOptions.Compiled);

            if (!validEmailRegex.IsMatch(user.Email))
                throw new Exception("Invalid Email Format");

            if (user.CPF.Length != 11)
                throw new Exception("Invalid CPF Format");

            if (user.Password.Length <= 3)
                throw new Exception("Password must have more than four characters");
        }
    }
}
