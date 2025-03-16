using Domain.Models;
using MediatR;

namespace Application.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<OperationResult<bool>>
    {
        public CreateBookCommand(Book bookToAdd)
        {
            BookToAdd = bookToAdd;
        }
        public Book BookToAdd { get;}
    }
}
