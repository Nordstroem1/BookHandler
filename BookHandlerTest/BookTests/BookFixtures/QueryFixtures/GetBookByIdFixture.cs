using Infrastructure.Databases;
using FakeItEasy;
using AutoMapper;
using Application.MappingProfiles;
using Application.Books.Queries.GetById;
namespace BookHandlerTest.BookTests.BookFixtures.QueryFixtures
{
    public class GetBookByIdFixture
    {
        public FakeDatabase FakeDatabase { get; }
        public GetBookByIdQueryHandler GetBookByIdCommand { get; }
        public Mapper _mapper { get; }
        public GetBookByIdFixture()
        {
            var fixture = new AutoFixture.Fixture();
            FakeDatabase = A.Fake<FakeDatabase>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new BookmappingProfile())));
            GetBookByIdCommand = new GetBookByIdQueryHandler(FakeDatabase, _mapper);
        }
    }
}
