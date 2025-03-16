using AutoMapper;
using Application.Dtos;
using Domain.Models;
namespace Application.MappingProfiles
{
    public class AuthormappingProfile : Profile
    {
        public AuthormappingProfile()
        {
            CreateMap<Author, AuthorDto>();
        }
    }
}
