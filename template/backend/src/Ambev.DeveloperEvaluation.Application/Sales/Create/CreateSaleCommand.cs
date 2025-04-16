using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Create
{
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public DateTime SaleDate { get; set; }
        public List<CreateSaleItemDto> Items { get; set; } = new();
    }

    public class CreateSaleItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

}
