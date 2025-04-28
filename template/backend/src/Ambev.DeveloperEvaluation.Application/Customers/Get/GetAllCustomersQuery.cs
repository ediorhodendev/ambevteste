using Ambev.DeveloperEvaluation.Application.Customers.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Customers.Get
{
    public class GetAllCustomersQuery : IRequest<List<CustomerDto>>
    {
    }
}
