using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Databases;
using MediatR;

namespace Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private IGenericRepository<Book> _genericRepository;
        public DeleteBookCommandHandler(IGenericRepository<Book> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingBook = await _genericRepository.GetByIdAsync(Guid.Parse(request.BookId));

                if (existingBook == null)
                {
                    return false;
                }
                
                var bookDeleted = await _genericRepository.DeleteAsync(existingBook);

                return true;
            }
            catch
            {
                throw new Exception("Something went wrong when deleting the book.");
            }
        }
    }
}
