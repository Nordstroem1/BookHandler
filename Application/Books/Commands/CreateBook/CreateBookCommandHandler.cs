using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, OperationResult<bool>>
    {
        private IGenericRepository<Book> _genericRepository;
        public CreateBookCommandHandler(IGenericRepository<Book> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<OperationResult<bool>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingBook = await _genericRepository.GetByIdAsync(request.BookToAdd.Id);

                if (existingBook != null )
                {
                    return OperationResult<bool>.Fail("There is already an book like that in the Database");  
                }

                Book addedBook = await _genericRepository.AddAsync(request.BookToAdd);

                return OperationResult<bool>.Success(true);
            }
            catch
            {
                throw new Exception("Something went wrong while adding the book.");
            }
        }
    }
}
