using Infrastructure.Databases;
using FakeItEasy;
using Application.Books.Queries.Books.GetById;
using AutoMapper;
using FakeItEasy.Sdk;
using Application.MappingProfiles;
namespace BookHandlerTest.Fixtures
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
