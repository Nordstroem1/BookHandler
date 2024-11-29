using Infrastructure.Databases;
using FakeItEasy;
using AutoMapper;
using Application.MappingProfiles;
using Application.Books.Queries.GetById;
using Domain.Interfaces;
using Domain.Models;
using Application.Dtos;
namespace BookHandlerTest.BookTests.BookFixtures.QueryFixtures
{
    public class GetBookByIdFixture
    {
        public IGenericRepository<BookDto> genericRepository { get; }
        public GetBookByIdQueryHandler GetBookByIdCommand { get; }
        public Mapper _mapper { get; }
        public GetBookByIdFixture()
        {
            var fixture = new AutoFixture.Fixture();
            genericRepository = A.Fake<IGenericRepository<BookDto>>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new BookmappingProfile())));
            GetBookByIdCommand = new GetBookByIdQueryHandler(genericRepository, _mapper);
        }
    }
}
