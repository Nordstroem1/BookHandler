//using Application.Dtos;
//using Application.Services;
//using AutoFixture;
//using AutoFixture.AutoFakeItEasy;
//using AutoMapper;
//using Domain.Models;
//using FakeItEasy;
//using FluentAssertions;
//using Infrastructure.Databases;
//using Xunit.Abstractions;
//namespace BookHandlerTest.ServiceTests
//{
//    public class AuthorTest
//    {
//        private readonly AuthorService _authorService;
//        private readonly FakeDatabase _fakeDatabase;
//        private ITestOutputHelper _outputter;
//        private readonly IMapper _mapper;
//        public AuthorTest(ITestOutputHelper outputter)
//        {
//            _outputter = outputter;
//            _fakeDatabase = A.Fake<FakeDatabase>();
            
//            var fixture = new Fixture().Customize(new AutoFakeItEasyCustomization());
//            _mapper = fixture.Create<IMapper>();
            
//            _authorService = new AuthorService(_fakeDatabase, _mapper);
//        }

//        [Fact]
//        [Trait("AuthorTest", "HappyCases")]
//        public void GetAllAuthors_WhenCalled_ShouldReturnsListOfAuthors()
//        {
//            //Arrange
//            var author1 = new Author(Guid.NewGuid(), "author1", new DateOnly(2000, 03, 27), "Sundsvall");
//            var author2 = new Author(Guid.NewGuid(), "author2", new DateOnly(1984, 10, 22), "Borås");
//            var authorList = new List<Author>
//            {
//                author1,
//                author2
//            };
//            A.CallTo(() => _fakeDatabase.GetAllAuthors()).Returns(authorList);

//            //Act
//            var result = _authorService.GetAllAuthors();
//            //Arrange
//            result.Should().BeOfType<List<Author>>().And.BeEquivalentTo(authorList);
//        }
//    }
//}
