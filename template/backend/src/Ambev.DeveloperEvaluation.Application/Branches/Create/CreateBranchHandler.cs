using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Branches.Create
{
    public class CreateBranchHandler : IRequestHandler<CreateBranchCommand, CreateBranchResult>
    {
        private readonly IBranchRepository _repository;
        private readonly ILogger<CreateBranchHandler> _logger;
        private readonly IMapper _mapper;

        public CreateBranchHandler(IBranchRepository repository, ILogger<CreateBranchHandler> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CreateBranchResult> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Branch>(request);
            var created = await _repository.CreateAsync(entity, cancellationToken);
            _logger.LogInformation("BranchCreated event published for BranchId: {BranchId}", created.Id);
            return _mapper.Map<CreateBranchResult>(created);
        }
    }
}
