using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Product.Update
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<UpdateProductHandler> _logger;

        public UpdateProductHandler(IProductRepository repository, ILogger<UpdateProductHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (product == null) return false;

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;

            var success = await _repository.UpdateAsync(product, cancellationToken);
            if (success)
                _logger.LogInformation("ProductUpdated event published for ProductId: {ProductId}", product.Id);

            return success;
        }
    }
}
