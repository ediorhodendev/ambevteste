using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.Create
{
    public class CreateSaleResult
    {
        public Guid SaleId { get; set; }
        public decimal Total { get; set; }
        public bool Cancelled { get; set; }
    }
}
