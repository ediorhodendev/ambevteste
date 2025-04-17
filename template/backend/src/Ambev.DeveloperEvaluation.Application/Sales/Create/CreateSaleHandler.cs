using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Common.Events;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation; 
using MediatR;
using Microsoft.Extensions.Logging;
using ValidationException = FluentValidation.ValidationException;

namespace Ambev.DeveloperEvaluation.Application.Sales.Create
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {

       



        private readonly ISaleRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateSaleHandler> _logger;
        private readonly IEventPublisher _eventPublisher;

        public CreateSaleHandler(ISaleRepository repository, IMapper mapper, ILogger<CreateSaleHandler> logger, IEventPublisher eventPublisher)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _eventPublisher = eventPublisher;
        }





        public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors); // ✅ Corrigido para FluentValidation

            var sale = new Sale
            {
                Id = Guid.NewGuid(),
                CustomerId = command.CustomerId,
                BranchId = command.BranchId,
                Date = command.SaleDate,
                Cancelled = false,
                Items = command.Items.Select(i => new SaleItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    Discount = i.Quantity >= 10 ? 0.2m : i.Quantity > 4 ? 0.1m : 0.0m
                }).ToList()
            };

            await _repository.CreateAsync(sale, cancellationToken);

            _logger.LogInformation("SaleCreated event published for SaleId: {SaleId}", sale.Id);

            await _eventPublisher.PublishAsync(sale, "SaleCreated", cancellationToken);

            var result = new CreateSaleResult
            {
                SaleId = sale.Id,
                Total = sale.Items.Sum(i => (i.UnitPrice * i.Quantity) * (1 - i.Discount)),
                Cancelled = sale.Cancelled
            };

            return result;
        }
    }
}
