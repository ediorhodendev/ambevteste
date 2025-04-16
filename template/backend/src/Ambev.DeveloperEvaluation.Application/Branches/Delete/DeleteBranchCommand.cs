using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.Delete
{
    public class DeleteBranchCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
