using Domain.Models;
using MediatR;
namespace Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest<bool>
    {
        public UpdateAuthorCommand(Author authorToUpdate) 
        {
            authorToUpdate = Author;
        }
        public Author Author { get; set; }
    }
}

