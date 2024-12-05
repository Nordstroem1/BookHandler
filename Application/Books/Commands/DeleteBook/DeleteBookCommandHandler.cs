using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Databases;
using MediatR;

namespace Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, OperationResult<bool>>
    {
        private IGenericRepository<Book> _genericRepository;
        public DeleteBookCommandHandler(IGenericRepository<Book> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<OperationResult<bool>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _genericRepository.GetByIdAsync(Guid.Parse(request.BookId));

                if(result == null)
                {
                    return OperationResult<bool>.Fail("Book not found.");
                }
                
                var bookDeleted = await _genericRepository.DeleteAsync(result);
                if (bookDeleted != null)
                {
                    return OperationResult<bool>.Fail("Failure while deleting the book.");
                }

                return OperationResult<bool>.Success(true);
            }
            catch(Exception ex)
            {
                return OperationResult<bool>.Fail(ex.Message);
            }
        }
    }
}
