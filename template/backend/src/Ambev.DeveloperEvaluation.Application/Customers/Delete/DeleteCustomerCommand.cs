using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.Delete
{
    public class DeleteCustomerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
