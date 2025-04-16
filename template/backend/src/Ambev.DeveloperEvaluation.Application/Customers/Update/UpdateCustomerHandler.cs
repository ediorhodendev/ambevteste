using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Customers.Update
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly ICustomerRepository _repository;
        private readonly ILogger<UpdateCustomerHandler> _logger;

        public UpdateCustomerHandler(ICustomerRepository repository, ILogger<UpdateCustomerHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (existing == null) return false;

            existing.Name = request.Name;
            existing.Email = request.Email;
            existing.Phone = request.Phone;

            var success = await _repository.UpdateAsync(existing, cancellationToken);

            if (success)
                _logger.LogInformation("CustomerUpdated event published for CustomerId: {CustomerId}", request.Id);

            return success;
        }
    }
}
