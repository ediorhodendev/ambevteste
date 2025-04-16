using Ambev.DeveloperEvaluation.Application.Product.Update;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.Update
{
    public class UpdateProductProfile : Profile
    {
        public UpdateProductProfile()
        {
            CreateMap<UpdateProductRequest, UpdateProductCommand>();
        }
    }
}
