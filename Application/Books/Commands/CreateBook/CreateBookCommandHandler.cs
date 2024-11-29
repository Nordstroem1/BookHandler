using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Databases;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, bool>
    {
        private IGenericRepository<Book> _genericRepository;
        public CreateBookCommandHandler(IGenericRepository<Book> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<bool> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingBook = await _genericRepository.GetByIdAsync(request.BookToAdd.Id);

                if (existingBook.Title != string.Empty || existingBook.Id != Guid.Empty)
                {
                    return await Task.FromResult(false);
                }

                Book addedBook = await _genericRepository.AddAsync(request.BookToAdd);

                if (addedBook != null)
                {
                    return await Task.FromResult(true);
                }
                else
                {
                    throw new Exception("Book not added");
                }
            }
            catch
            {
                throw new Exception("Something went wrong while adding the book.");
            }
        }
    }
}
