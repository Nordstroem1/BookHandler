using Application.Authors.Queries.GetAuthorById;
using Application.Dtos;
using Application.MappingProfiles;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using FakeItEasy;

namespace BookHandlerTest.AuthorTests.AuthorFixtures.QueryFixtures
{
    public class GetAuthorByIdFixture
    {
        public IGenericRepository<AuthorDto> _genericRepository{ get; }
        public GetAuthorByIdQueryHandler getAuthorByIdQueryHandler { get; }
        public IMapper mapper { get; }
        public GetAuthorByIdFixture()
        {
            var fixture = new AutoFixture.Fixture();
            _genericRepository = A.Fake<IGenericRepository<AuthorDto>>();
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new AuthormappingProfile())));
            getAuthorByIdQueryHandler = new GetAuthorByIdQueryHandler(_genericRepository, mapper);
        }
    }
}
