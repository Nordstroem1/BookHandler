using Domain.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, OperationResult<bool>>
    {
        private readonly IGenericRepository<Author> _genericRepository;
        private readonly ILogger<CreateAuthorCommandHandler> _logger;   
        public CreateAuthorCommandHandler(IGenericRepository<Author> genericRepository, ILogger<CreateAuthorCommandHandler> logger)
        {
            _logger = logger;
            _genericRepository = genericRepository;
        }
        public async Task<OperationResult<bool>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var authorAdded = await _genericRepository.AddAsync(request.Author);

                if (authorAdded != null)
                {
                    _logger.LogInformation("Author added successfully. Author details: {@Author}", request.Author);
                    return OperationResult<bool>.Success(true);
                }
                else
                {
                    _logger.LogWarning("Could not add author. Author details: ", request.Author);
                    return OperationResult<bool>.Fail("Something went wrong while adding the author.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception occurred while adding the author. Author details: ", request.Author);
                return OperationResult<bool>.Fail("An error occurred while adding the author.");
            }
        }
    }
}
