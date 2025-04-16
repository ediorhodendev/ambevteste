using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.Get
{
    public class GetSaleWebProfile : Profile
    {
        public GetSaleWebProfile()
        {
            CreateMap<GetSaleResult, GetSaleResponse>();
            CreateMap<GetSaleItemResult, GetSaleItemResponse>();
        }
    }
}
