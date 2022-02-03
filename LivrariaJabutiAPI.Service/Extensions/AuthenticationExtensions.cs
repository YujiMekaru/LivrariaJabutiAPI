using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Service.Extensions
{
    public static class AuthenticationExtensions
    {
        public static string ToMD5(this string? password)
        {
            ArgumentNullException.ThrowIfNull(password);

            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }


        public static DateOnly ToDateOnly(this string? date)
        {
            ArgumentNullException.ThrowIfNull(date);

            var splitDate = date.Split('/');
            
            if (splitDate.Length != 3)
                throw new ArgumentException("Failed to convert date. Expected format: dd/MM/yyyy");
            
            return new DateOnly(int.Parse(splitDate[2]), int.Parse(splitDate[1]), int.Parse(splitDate[0]));
        }
    }

    
}
