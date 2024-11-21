using Application.Authors.Queries.GetAllAuthors;
using Application.Authors.Queries.GetAuthorById;
using Application.MappingProfiles;
using AutoMapper;
using FakeItEasy;
using Infrastructure.Databases;

namespace BookHandlerTest.AuthorTests.AuthorFixtures.QueryFixtures
{
    public class GetAuthorByIdFixture
    {
        public FakeDatabase fakeDatabase { get; }
        public GetAuthorByIdCommandHandler getAuthorByIdQueryHandler { get; }
        public IMapper mapper { get; }
        public GetAuthorByIdFixture()
        {
            var fixture = new AutoFixture.Fixture();
            fakeDatabase = A.Fake<FakeDatabase>();
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new AuthormappingProfile())));
            getAuthorByIdQueryHandler = new GetAuthorByIdCommandHandler(fakeDatabase, mapper);
        }
    }
}
