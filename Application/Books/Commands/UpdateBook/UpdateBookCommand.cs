using Domain.Models;
using MediatR;
using System.Security.AccessControl;

namespace Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest<OperationResult<bool>>
    {
        public UpdateBookCommand(Book bookToUpdate)
        {
            Book = bookToUpdate;
        }
        public Book Book { get; }
    }
}
