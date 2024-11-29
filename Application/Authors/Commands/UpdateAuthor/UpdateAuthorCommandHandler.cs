
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
                var foundAuthor = await _genericRepository.GetByIdAsync(request.Author.Id);

                if (foundAuthor == null)
                {
                    return false;
                }

                foundAuthor.Name = request.Author.Name;
                foundAuthor.DateOfBirth = request.Author.DateOfBirth;
                foundAuthor.PlaceOfBirth = request.Author.PlaceOfBirth; 

                var authorUpdated = await _genericRepository.UpdateAsync(foundAuthor);

                return true; 
            }
            catch
            {
                throw new Exception("Something went wrong while updating the author.");
            }
        }
    }
}
