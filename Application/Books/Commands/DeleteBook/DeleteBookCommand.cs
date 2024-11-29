
using Domain.Models;
using MediatR;

namespace Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<bool>
    {
        public DeleteBookCommand(string bookId)
        {
            BookId = bookId;
        }
        public string BookId { get; }
    }
}
