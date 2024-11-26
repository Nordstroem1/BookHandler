
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Databases;
using MediatR;

namespace Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, bool>
    {
        private readonly IGenericRepository<Author> _genericRepository;
        public UpdateAuthorCommandHandler(IGenericRepository<Author> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var authorUpdated = await _genericRepository.UpdateAsync(request.Author);
                
                if (authorUpdated != request.Author)
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
