namespace Ambev.DeveloperEvaluation.Application.Sales.Dtos;


    public class SaleDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } // Descrição
        public Guid BranchId { get; set; }
        public string BranchName { get; set; } // Descrição
        public DateTime Date { get; set; }
        public bool Cancelled { get; set; }
        public decimal Total => Items.Sum(i => (i.UnitPrice * i.Quantity) - ((i.UnitPrice * i.Quantity) * i.Discount));
        public List<SaleItemDto> Items { get; set; }
    }

    


