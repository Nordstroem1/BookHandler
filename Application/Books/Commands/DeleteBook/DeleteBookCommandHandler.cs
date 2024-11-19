using Infrastructure.Databases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly FakeDatabase _database;
        public DeleteBookCommandHandler(FakeDatabase database)
        {
            _database = database;
        }
        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingBook = await _database.GetBook(Guid.Parse(request.BookId));
                if (existingBook.Id == Guid.Empty || existingBook.Title == string.Empty)
                {
                    bool bookDeleted = await _database.DeleteBook(Guid.Parse(request.BookId));

                    if (bookDeleted)
                    {
                        return await Task.FromResult(true);
                    }
                }

                return await Task.FromResult(false);
            }
            catch
            {
                throw new Exception("Something went wrong when deleting the book.");
            }
        }
    }
}
