using Application.Books.Queries.GetAllBooks;
using FakeItEasy;
using Infrastructure.Databases;

namespace BookHandlerTest.BookTests.BookFixtures.QueryFixtures
{
    public class GetAllBooksFixture
    {
        public FakeDatabase FakeDatabase { get; }
        public GetAllBooksCommandHandler GetBookByIdCommand { get; }
        public GetAllBooksFixture()
        {
            var fixture = new AutoFixture.Fixture();
            FakeDatabase = A.Fake<FakeDatabase>();
            GetBookByIdCommand = new GetAllBooksCommandHandler(FakeDatabase);
        }
    }
}
