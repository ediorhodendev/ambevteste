using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.Get
{
    public class GetBranchCommand : IRequest<GetBranchResult?>
    {
        public Guid Id { get; set; }
    }
}
