using Ambev.DeveloperEvaluation.Application.Sales.Dtos;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Get
{
    public class GetAllSalesQuery : IRequest<List<SaleDto>>
    {
    }
}
