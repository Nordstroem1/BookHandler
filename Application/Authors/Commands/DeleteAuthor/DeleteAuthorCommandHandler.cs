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
                var foundAuthor = await _genericRepository.GetByIdAsync(Convert.ToInt32(request.AuthorId));
                var result = false;

                if (foundAuthor != null)
                {
                    result = true;
                    await _genericRepository.DeleteAsync(foundAuthor);
                }

                return result;
            }
            catch
            {
                throw new Exception("Author not found");
            }
        }
    }
}
