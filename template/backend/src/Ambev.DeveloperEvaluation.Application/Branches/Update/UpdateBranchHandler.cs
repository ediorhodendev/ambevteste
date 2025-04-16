using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Branches.Update
{
    public class UpdateBranchHandler : IRequestHandler<UpdateBranchCommand, bool>
    {
        private readonly IBranchRepository _repository;
        private readonly ILogger<UpdateBranchHandler> _logger;

        public UpdateBranchHandler(IBranchRepository repository, ILogger<UpdateBranchHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (branch == null) return false;

            branch.Name = request.Name;
            branch.Location = request.Location;

            var success = await _repository.UpdateAsync(branch, cancellationToken);
            if (success)
                _logger.LogInformation("BranchUpdated event published for BranchId: {BranchId}", branch.Id);

            return success;
        }
    }
}
