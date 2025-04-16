using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

using Ambev.DeveloperEvaluation.Application.Sales.Dtos;

namespace Ambev.DeveloperEvaluation.Application.Sales.Get
{
    public class GetAllSalesHandler : IRequestHandler<GetAllSalesQuery, List<SaleDto>>
    {
        private readonly ISaleRepository _repository;
        private readonly IMapper _mapper;

        public GetAllSalesHandler(ISaleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<SaleDto>> Handle(GetAllSalesQuery request, CancellationToken cancellationToken)
        {
            var sales = await _repository.GetAllIncludingAsync(cancellationToken);
            return _mapper.Map<List<SaleDto>>(sales);
        }

    }
}