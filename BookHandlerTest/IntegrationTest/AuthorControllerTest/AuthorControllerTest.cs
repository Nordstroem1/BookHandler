using FakeItEasy;
using MediatR;
using Microsoft.Extensions.Logging;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Application.Authors.Queries.GetAuthorById;
using Application.Dtos;
using AutoMapper;

namespace BookHandlerTest.Integration.AuthorController
{
    public class AuthorControllerTest
    {
        private readonly IMediator _fakeMediator;
        private readonly ILogger<BookApi.Controllers.AuthorController> _fakeLogger;
        private readonly BookApi.Controllers.AuthorController _controller;
        private readonly IMapper _mapper;

        public AuthorControllerTest()
        {
            _fakeMediator = A.Fake<IMediator>();
            _fakeLogger = A.Fake<ILogger<BookApi.Controllers.AuthorController>>();
            _controller = new BookApi.Controllers.AuthorController(_fakeMediator, _fakeLogger);
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        [Trait("IntegrationTest", "GetById")]
        public async Task Test_GetAuthorById()
        {
            // Arrange
            var authorId = Guid.NewGuid();
            var expectedAuthor = new Author(authorId, "author1", new DateOnly(2000, 03, 27), "place1");
            var expectedAuthorDto = new AuthorDto(authorId, expectedAuthor.Name);
            var query = new GetAuthorByIdQuery(authorId);
            var operationResult = OperationResult<AuthorDto>.Success(new AuthorDto { Id = authorId, Name = expectedAuthor.Name });

            A.CallTo(() => _fakeMediator.Send(A<GetAuthorByIdQuery>.That.Matches(q => q.AuthorId == authorId), default))
                .Returns(Task.FromResult(operationResult));

            A.CallTo(() => _mapper.Map<AuthorDto>(expectedAuthor)).Returns(expectedAuthorDto);

            // Act
            var result = _controller.GetAuthorById(authorId.ToString()) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode); 
            Assert.NotNull(result.Value);
            
            var mappedAuthor = _mapper.Map<AuthorDto>(expectedAuthor);
            Assert.Equal(expectedAuthorDto.Id, mappedAuthor.Id);
            Assert.Equal(expectedAuthor.Name, mappedAuthor.Name);

            A.CallTo(() => _fakeMediator.Send(A<GetAuthorByIdQuery>.That.Matches(q => q.AuthorId == authorId), default))
                .MustHaveHappenedOnceExactly();
        }
    }
}
