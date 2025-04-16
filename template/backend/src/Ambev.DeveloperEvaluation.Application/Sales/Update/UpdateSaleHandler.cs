using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation; // ✅ Corrigido para usar FluentValidation
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.Update
{
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, bool>
    {
        private readonly ISaleRepository _repository;
        private readonly ILogger<UpdateSaleHandler> _logger;

        public UpdateSaleHandler(ISaleRepository repository, ILogger<UpdateSaleHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSaleCommandValidator();
            var validation = await validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
                throw new ValidationException(validation.Errors); 

            var sale = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (sale == null)
                return false;

            sale.CustomerId = request.CustomerId;
            sale.BranchId = request.BranchId;
            sale.Date = request.Date;
            sale.Cancelled = request.Cancelled;
            sale.Items = request.Items.Select(i => new SaleItem
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice,
                Discount = i.Discount
            }).ToList();

            await _repository.UpdateAsync(sale, cancellationToken);

            _logger.LogInformation("SaleUpdated event published for SaleId: {SaleId}", request.Id);

            return true;
        }
    }
}
