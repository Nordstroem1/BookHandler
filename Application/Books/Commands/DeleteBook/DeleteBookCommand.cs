
using Domain.Models;
using MediatR;

namespace Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<OperationResult<bool>>
    {
        public DeleteBookCommand(string bookId)
        {
            BookId = bookId;
        }
        public string BookId { get; }
    }
}
