using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Get
{
    public class GetSaleHandler : IRequestHandler<GetSaleCommand, GetSaleResult?>
    {
        private readonly ISaleRepository _repository;
        private readonly IMapper _mapper;

        public GetSaleHandler(ISaleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetSaleResult?> Handle(GetSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = await _repository.GetByIdAsync(request.Id, cancellationToken);
            return sale == null ? null : _mapper.Map<GetSaleResult>(sale);
        }
    }
}
