using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public DateTime Date { get; set; }
        public bool Cancelled { get; set; }
        public List<SaleItem> Items { get; set; } = new();

        public Customer Customer { get; set; }

        public Branch Branch { get; set; }
    }
}
