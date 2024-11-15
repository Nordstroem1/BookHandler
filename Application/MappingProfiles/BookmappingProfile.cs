using AutoMapper;
using Application.Dtos;
using Domain.Models;

namespace Application.MappingProfiles
{
    public class BookmappingProfile : Profile
    {
        public BookmappingProfile()
        {
            CreateMap<Book, BookDto>();
        }
    }
}
