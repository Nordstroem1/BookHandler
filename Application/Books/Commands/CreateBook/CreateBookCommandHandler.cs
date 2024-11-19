using Domain.Models;
using Infrastructure.Databases;
using MediatR;

namespace Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, bool>
    {
        private readonly FakeDatabase _database;
        public CreateBookCommandHandler(FakeDatabase database)
        {
            _database = database;
        }
        public async Task<bool> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingBook = _database.GetBook(request.BookToAdd.Id);
                if (existingBook != null)
                {
                    throw new Exception("Book already exists");
                }

                bool bookAdded = await _database.AddBook(request.BookToAdd);

                if (bookAdded)
                {
                    return await Task.FromResult(true);
                }
                else
                {
                    throw new Exception("Book not added");
                }
            }
            catch
            {
                throw new Exception("Something went wrong while adding the book.");
            }
        }
    }
}
