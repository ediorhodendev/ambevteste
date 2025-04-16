using Ambev.DeveloperEvaluation.Application.Sales.Create;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Create
{
    public class CreateSaleProfile : Profile
    {
        public CreateSaleProfile()
        {
            CreateMap<CreateSaleRequest, CreateSaleCommand>();
            CreateMap<CreateSaleItemRequest, CreateSaleItemDto>();
            CreateMap<CreateSaleResult, CreateSaleResponse>();
        }
    }
}
