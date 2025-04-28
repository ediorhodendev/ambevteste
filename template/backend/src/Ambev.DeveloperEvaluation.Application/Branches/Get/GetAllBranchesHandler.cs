using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Branches.Dtos;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Branches.Get
{
    public class GetAllBranchesHandler : IRequestHandler<GetAllBranchesQuery, List<BranchDto>>
    {
        private readonly IBranchRepository _repository;
        private readonly IMapper _mapper;

        public GetAllBranchesHandler(IBranchRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<BranchDto>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            var branches = await _repository.GetAllIncludingAsync(cancellationToken);
            return _mapper.Map<List<BranchDto>>(branches);
        }
    }
}
