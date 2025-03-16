
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Databases;
using MediatR;

namespace Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, OperationResult<bool>>
    {
        private readonly IGenericRepository<Author> _genericRepository;
        public UpdateAuthorCommandHandler(IGenericRepository<Author> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<OperationResult<bool>> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var foundAuthor = await _genericRepository.GetByIdAsync(request.Author.Id);

                if (foundAuthor == null)
                {
                    return OperationResult<bool>.Fail("Author Id is invalid");
                }

                foundAuthor.Name = request.Author.Name;
                foundAuthor.DateOfBirth = request.Author.DateOfBirth;
                foundAuthor.PlaceOfBirth = request.Author.PlaceOfBirth; 

                var authorUpdated = await _genericRepository.UpdateAsync(foundAuthor);

                return OperationResult<bool>.Success(true);
            }
            catch
            {
                return OperationResult<bool>.Fail("something went wrong in the commandhandler");
            }
        }
    }
}
