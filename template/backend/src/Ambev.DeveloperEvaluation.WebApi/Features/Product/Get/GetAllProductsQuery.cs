using MediatR;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Application.Products.Dtos;

namespace Ambev.DeveloperEvaluation.Application.Products.Get
{
    public class GetAllProductsQuery : IRequest<List<ProductDto>>
    {
    }
}
