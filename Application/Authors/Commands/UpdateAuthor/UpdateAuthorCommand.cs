using Domain.Models;
using MediatR;
namespace Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest<OperationResult<bool>>
    {
        public UpdateAuthorCommand(Author authorToUpdate) 
        {
            Author = authorToUpdate;
        }
        public Author Author { get; set; }
    }
}

