using Ambev.DeveloperEvaluation.Application.Branches.Create;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.Create
{
    public class CreateBranchProfile : Profile
    {
        public CreateBranchProfile()
        {
            CreateMap<CreateBranchRequest, CreateBranchCommand>();
            CreateMap<CreateBranchResult, CreateBranchResponse>();
            CreateMap<CreateBranchCommand, Branch>();
            CreateMap<Branch, CreateBranchResult>();
        }
    }
}
