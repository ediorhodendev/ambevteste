using Ambev.DeveloperEvaluation.Application.Product.Get;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.Get
{
    public class GetProductProfile : Profile
    {
        public GetProductProfile()
        {
            CreateMap<GetProductResult, GetProductResponse>();
        }
    }
}
