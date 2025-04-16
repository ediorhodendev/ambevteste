using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.Delete
{
    public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, bool>
    {
        private readonly ISaleRepository _repository;
        private readonly ILogger<DeleteSaleHandler> _logger;

        public DeleteSaleHandler(ISaleRepository repository, ILogger<DeleteSaleHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
        {
            var success = await _repository.DeleteAsync(request.Id, cancellationToken);
            if (success)
                _logger.LogInformation("SaleDeleted event published for SaleId: {SaleId}", request.Id);

            return success;
        }
    }
}
