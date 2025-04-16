using Ambev.DeveloperEvaluation.Application.Product.Create;
using AutoMapper;
using ProductEntity = Ambev.DeveloperEvaluation.Domain.Entities.Product;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.Create
{
    public class CreateProductProfile : Profile
    {
        public CreateProductProfile()
        {
            CreateMap<CreateProductRequest, CreateProductCommand>();
            CreateMap<CreateProductResult, CreateProductResponse>();
            CreateMap<CreateProductCommand, ProductEntity>();
            CreateMap<ProductEntity, CreateProductResult>();
        }
    }
}

