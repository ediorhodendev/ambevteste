using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Branches.Delete
{
    public class DeleteBranchHandler : IRequestHandler<DeleteBranchCommand, bool>
    {
        private readonly IBranchRepository _repository;
        private readonly ILogger<DeleteBranchHandler> _logger;

        public DeleteBranchHandler(IBranchRepository repository, ILogger<DeleteBranchHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var success = await _repository.DeleteAsync(request.Id, cancellationToken);

            if (success)
                _logger.LogInformation("BranchDeleted event published for BranchId: {BranchId}", request.Id);

            return success;
        }
    }
}
