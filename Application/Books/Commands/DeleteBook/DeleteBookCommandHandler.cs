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
        public Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool bookDeleted = _database.DeleteBook(Guid.Parse(request.BookId));
                if (!bookDeleted)
                {
                    return Task.FromResult(true);
                }

                return Task.FromResult(false);
            }
            catch
            {
                throw new Exception("Something went wrong when deleting the book.");
            }
        }
    }
}
