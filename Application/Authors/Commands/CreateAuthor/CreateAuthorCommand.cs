using Domain.Models;
using MediatR;

namespace Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<bool>
    {
        public CreateAuthorCommand(Author author)
        {
            Author = author;
        }
        public Author Author { get; }
    }
}
