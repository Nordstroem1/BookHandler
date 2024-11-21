using Infrastructure.Databases;
using MediatR;

namespace Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, bool>
    {
        public FakeDatabase FakeDatabase { get; }
        public CreateAuthorCommandHandler(FakeDatabase fakeDatabase)
        {
            FakeDatabase = fakeDatabase;
        }
        public async Task<bool> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool authorAdded = await FakeDatabase.CreateAuthor(request.Author);

                if (authorAdded)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw new Exception("Something went wrong while adding the author.");
            }
        }
    }
}
