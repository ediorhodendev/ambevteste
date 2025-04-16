using Ambev.DeveloperEvaluation.Application.Sales.Update;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Update
{
    public class UpdateSaleProfile : Profile
    {
        public UpdateSaleProfile()
        {
            CreateMap<UpdateSaleRequest, UpdateSaleCommand>();
            CreateMap<UpdateSaleItemRequest, UpdateSaleItemDto>();
        }
    }
}
