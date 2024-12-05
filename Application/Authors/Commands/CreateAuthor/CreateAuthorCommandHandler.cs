using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, OperationResult<bool>>
    {
        private readonly IGenericRepository<Author> _genericRepository;
        public CreateAuthorCommandHandler(IGenericRepository<Author> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<OperationResult<bool>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorAdded = await _genericRepository.AddAsync(request.Author);

            if (authorAdded != null)
            {
                return OperationResult<bool>.Success(true);
            }
            else
            {
                return OperationResult<bool>.Fail("Something went wrong while adding the author.");
            }
        }
    }
}
