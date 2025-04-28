using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Branches.Dtos;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Branches.Get
{
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<Branch, GetBranchResult>();
            CreateMap<Branch, BranchDto>();

        }
    }
}
