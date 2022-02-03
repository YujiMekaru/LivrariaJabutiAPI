using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Domain.Entities.Users
{
    [Owned]
    public class UserAddress
    {
        [Column(TypeName = "varchar(255)")]
        public string? ZipCode { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? Street { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? Number { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? District { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? City { get; set; }

    }
}
