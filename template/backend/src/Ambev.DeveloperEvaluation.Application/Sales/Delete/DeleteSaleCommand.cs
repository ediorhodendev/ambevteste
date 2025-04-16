using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Delete
{
    public class DeleteSaleCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
