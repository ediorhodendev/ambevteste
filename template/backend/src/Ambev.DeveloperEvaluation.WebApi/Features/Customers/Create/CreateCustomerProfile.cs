using Ambev.DeveloperEvaluation.Application.Customers.Create;
using Ambev.DeveloperEvaluation.Application.Customers.Dtos;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.Create
{
    public class CreateCustomerProfile : Profile
    {
        public CreateCustomerProfile()
        {
            CreateMap<CreateCustomerRequest, CreateCustomerCommand>();
            CreateMap<CreateCustomerResult, CreateCustomerResponse>();
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<Customer, CreateCustomerResult>();
            CreateMap<Customer, CustomerDto>();

        }
    }
}
