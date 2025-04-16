using Ambev.DeveloperEvaluation.Application.Customers.Update;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.Update
{
    public class UpdateCustomerProfile : Profile
    {
        public UpdateCustomerProfile()
        {
            CreateMap<UpdateCustomerRequest, UpdateCustomerCommand>();
        }
    }
}
