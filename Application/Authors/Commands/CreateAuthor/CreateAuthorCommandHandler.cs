using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, bool>
    {
        private readonly IGenericRepository<Author> _genericRepository;
        public CreateAuthorCommandHandler(IGenericRepository<Author> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<bool> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var authorAdded = await _genericRepository.AddAsync(request.Author);

                if (authorAdded != null)
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
