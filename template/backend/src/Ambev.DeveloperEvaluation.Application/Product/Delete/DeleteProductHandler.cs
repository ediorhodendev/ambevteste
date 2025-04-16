using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Product.Delete
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<DeleteProductHandler> _logger;

        public DeleteProductHandler(IProductRepository repository, ILogger<DeleteProductHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var success = await _repository.DeleteAsync(request.Id, cancellationToken);

            if (success)
                _logger.LogInformation("ProductDeleted event published for ProductId: {ProductId}", request.Id);

            return success;
        }
    }

}
