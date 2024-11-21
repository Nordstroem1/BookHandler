using MediatR;
namespace Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest<bool>
    {
        public Guid AuthorId { get; set; }
        public DeleteAuthorCommand(Guid authorId)
        {
            AuthorId = authorId;
        }
    }
}
