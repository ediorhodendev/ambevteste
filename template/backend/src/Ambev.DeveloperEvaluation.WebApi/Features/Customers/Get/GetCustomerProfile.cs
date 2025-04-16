using Ambev.DeveloperEvaluation.Application.Customers.Get;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.Get
{
    public class GetCustomerProfile : Profile
    {
        public GetCustomerProfile()
        {
            CreateMap<GetCustomerResult, GetCustomerResponse>();
        }
    }
}
