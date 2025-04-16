using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Customers.Delete
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerRepository _repository;
        private readonly ILogger<DeleteCustomerHandler> _logger;

        public DeleteCustomerHandler(ICustomerRepository repository, ILogger<DeleteCustomerHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var success = await _repository.DeleteAsync(request.Id, cancellationToken);

            if (success)
                _logger.LogInformation("CustomerDeleted event published for CustomerId: {CustomerId}", request.Id);

            return success;
        }
    }

}
