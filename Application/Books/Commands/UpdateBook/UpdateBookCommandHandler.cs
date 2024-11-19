using Infrastructure.Databases;
using MediatR;

namespace Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        private readonly FakeDatabase _database;
        public UpdateBookCommandHandler(FakeDatabase database)
        {
            _database = database;
        }
        public Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool bookUpdated = _database.UpdateBook(request.Book.Id, request.Book);
                if (!bookUpdated)
                {
                    return Task.FromResult(false);
                }
                return Task.FromResult(true);
            }
            catch
            {
                throw new Exception("Something went wrong when updating the book.");
            }
        }
    }
}
