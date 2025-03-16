using Domain.Models;
using MediatR;
namespace Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest<OperationResult<bool>>
    {
        public Guid AuthorId { get; set; }
        public DeleteAuthorCommand(Guid authorId)
        {
            AuthorId = authorId;
        }
    }
}
