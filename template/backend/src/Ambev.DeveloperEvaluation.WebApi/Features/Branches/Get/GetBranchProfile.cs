using Ambev.DeveloperEvaluation.Application.Branches.Get;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.Get
{
    public class GetBranchProfile : Profile
    {
        public GetBranchProfile()
        {
            CreateMap<GetBranchResult, GetBranchResponse>();
        }
    }
}
