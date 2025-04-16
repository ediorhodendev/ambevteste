using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.Update
{
    public class UpdateSaleCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public DateTime Date { get; set; }
        public bool Cancelled { get; set; }
        public List<UpdateSaleItemDto> Items { get; set; } = new();
    }

    public class UpdateSaleItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
    }

}
