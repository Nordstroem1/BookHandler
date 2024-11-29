using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Databases;
using MediatR;

namespace Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        private IGenericRepository<Book> _genericRepository;
        public UpdateBookCommandHandler(IGenericRepository<Book> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var foundBook = await _genericRepository.GetByIdAsync(request.Book.Id);

                if (foundBook == null)
                {
                    return false;
                }

                foundBook.Title = request.Book.Title;
                foundBook.AuthorId = request.Book.AuthorId;
                foundBook.Pages = request.Book.Pages;

                await _genericRepository.UpdateAsync(foundBook);

                return true;
            }
            catch
            {
                throw new Exception("Something went wrong when updating the book.");
            }
        }
    }
}
