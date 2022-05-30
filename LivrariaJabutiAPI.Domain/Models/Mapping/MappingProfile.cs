using AutoMapper;
using LivrariaJabutiAPI.Domain.Entities.Books;
using LivrariaJabutiAPI.Domain.Models.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Domain.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookResponseDTO>();
            CreateMap<BookInsertDTO, Book>();
        }
    }
}
