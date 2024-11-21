using Infrastructure.Databases;
using MediatR;

namespace Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, bool>
    {
        private readonly FakeDatabase _database;
        public DeleteAuthorCommandHandler(FakeDatabase database)
        {
            _database = database;
        }
        public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool authorDeleted = await _database.DeleteAuthor(request.AuthorId);

                return authorDeleted;
            }
            catch
            {
                throw new Exception("Author not found");
            }
        }
    }
}
