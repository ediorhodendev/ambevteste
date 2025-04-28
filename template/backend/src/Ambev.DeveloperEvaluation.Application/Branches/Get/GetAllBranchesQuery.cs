using MediatR;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Application.Branches.Dtos;

namespace Ambev.DeveloperEvaluation.Application.Branches.Get
{
    public class GetAllBranchesQuery : IRequest<List<BranchDto>>
    {
    }
}
