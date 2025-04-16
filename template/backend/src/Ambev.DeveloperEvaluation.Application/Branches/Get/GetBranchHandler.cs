using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.Get
{
    public class GetBranchHandler : IRequestHandler<GetBranchCommand, GetBranchResult?>
    {
        private readonly IBranchRepository _repository;
        private readonly IMapper _mapper;

        public GetBranchHandler(IBranchRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetBranchResult?> Handle(GetBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = await _repository.GetByIdAsync(request.Id, cancellationToken);
            return branch == null ? null : _mapper.Map<GetBranchResult>(branch);
        }
    }
}
