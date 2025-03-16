using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Databases;
using MediatR;

namespace Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, OperationResult<bool>>
    {
        private readonly IGenericRepository<Author> _genericRepository;
        public DeleteAuthorCommandHandler(IGenericRepository<Author> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<OperationResult<bool>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var foundAuthor = await _genericRepository.GetByIdAsync(request.AuthorId);

            if (foundAuthor == null)
            {
                return OperationResult<bool>.Fail("Author not found");
            }

            var deletedAuthor = await _genericRepository.DeleteAsync(foundAuthor);

            return OperationResult<bool>.Success(true);
        }
    }
}
