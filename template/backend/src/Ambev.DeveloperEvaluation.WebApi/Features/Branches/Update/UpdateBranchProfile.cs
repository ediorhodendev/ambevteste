using Ambev.DeveloperEvaluation.Application.Branches.Update;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.Update
{
    public class UpdateBranchProfile : Profile
    {
        public UpdateBranchProfile()
        {
            CreateMap<UpdateBranchRequest, UpdateBranchCommand>();
        }
    }
}
