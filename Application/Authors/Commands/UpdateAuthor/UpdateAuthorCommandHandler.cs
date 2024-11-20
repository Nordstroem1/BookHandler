
using Infrastructure.Databases;
using MediatR;

namespace Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, bool>
    {
        public FakeDatabase fakeDatabase { get; }
        public UpdateAuthorCommandHandler(FakeDatabase fakeDatabase)
        {
            this.fakeDatabase = fakeDatabase;
        }
        public async Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool authorUpdated = await fakeDatabase.UpdateAuthor(request.Author);

                if (authorUpdated)
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
                throw new Exception("Something went wrong while updating the author.");
            }
        }
    }
}
