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
        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool bookUpdated = await _database.UpdateBook(request.Book.Id, request.Book);
                if (!bookUpdated)
                {
                    return await Task.FromResult(false);
                }
                return await Task.FromResult(true);
            }
            catch
            {
                throw new Exception("Something went wrong when updating the book.");
            }
        }
    }
}
