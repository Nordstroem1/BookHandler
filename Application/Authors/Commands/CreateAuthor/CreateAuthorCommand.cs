using Domain.Models;
using MediatR;

namespace Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<OperationResult<bool>>
    {
        public CreateAuthorCommand(Author author)
        {
            Author = author;
        }
        public Author Author { get; }
    }
}
