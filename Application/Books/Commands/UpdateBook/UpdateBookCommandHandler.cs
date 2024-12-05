using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Databases;
using MediatR;
using Microsoft.VisualBasic;

namespace Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, OperationResult<bool>>
    {
        private IGenericRepository<Book> _genericRepository;
        public UpdateBookCommandHandler(IGenericRepository<Book> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<OperationResult<bool>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var foundBook = await _genericRepository.GetByIdAsync(request.Book.Id);

                if (foundBook == null)
                {
                    return OperationResult<bool>.Fail("Could not find book.");
                }

                foundBook.Title = request.Book.Title;
                foundBook.AuthorId = request.Book.AuthorId;
                foundBook.Pages = request.Book.Pages;

                await _genericRepository.UpdateAsync(foundBook);

                return OperationResult<bool>.Success(true);
            }
            catch(Exception ex)
            {
                return OperationResult<bool>.Fail(ex.Message);
            }
        }
    }
}
