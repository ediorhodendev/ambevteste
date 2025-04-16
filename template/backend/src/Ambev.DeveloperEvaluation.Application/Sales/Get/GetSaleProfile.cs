using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Branches.Get;
using Ambev.DeveloperEvaluation.Application.Customers.Get;
using Ambev.DeveloperEvaluation.Application.Product.Get;
using Ambev.DeveloperEvaluation.Domain.Entities;
using ProductEntity = Ambev.DeveloperEvaluation.Domain.Entities.Product;

using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.Dtos;

namespace Ambev.DeveloperEvaluation.Application.Sales.Get
{
    public class GetSaleProfile : Profile
    {
        public GetSaleProfile()
        {
            CreateMap<Sale, GetSaleResult>();
            CreateMap<SaleItem, GetSaleItemResult>();
            CreateMap<Customer, GetCustomerResult>();
            CreateMap<Branch, GetBranchResult>();
            CreateMap<ProductEntity, GetProductResult>();


            CreateMap<SaleItem, SaleItemDto>()
           .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

            CreateMap<Sale, SaleDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.Name));



        }
    }
}
