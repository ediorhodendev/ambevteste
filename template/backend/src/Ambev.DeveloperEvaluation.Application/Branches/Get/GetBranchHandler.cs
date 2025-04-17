using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Customers.Create;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Branches.Get
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResult>
    {
        private readonly ICustomerRepository _repository;
        private readonly ILogger<CreateCustomerHandler> _logger;
        private readonly IMapper _mapper;

        public CreateCustomerHandler(ICustomerRepository repository, ILogger<CreateCustomerHandler> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CreateCustomerResult> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Customer>(request);
            var created = await _repository.CreateAsync(entity, cancellationToken);
            _logger.LogInformation("Customer created: {CustomerId}", created.Id);

            return _mapper.Map<CreateCustomerResult>(created);
        }
    }

}
