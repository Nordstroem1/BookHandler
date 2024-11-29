using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Databases;
using MediatR;

namespace Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, bool>
    {
        private readonly IGenericRepository<Author> _genericRepository;
        public DeleteAuthorCommandHandler(IGenericRepository<Author> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<bool> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var foundAuthor = await _genericRepository.GetByIdAsync(request.AuthorId);

                if (foundAuthor == null)
                {
                    return false;
                }

                var deletedAuthor = await _genericRepository.DeleteAsync(foundAuthor);

                return true;
            }
            catch
            {
                throw new Exception("Author not found");
            }
        }
    }
}
