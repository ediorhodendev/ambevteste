namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Update
{
    public class UpdateSaleRequest
    {
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public DateTime Date { get; set; }
        public bool Cancelled { get; set; }
        public List<UpdateSaleItemRequest> Items { get; set; } = new();
    }

    public class UpdateSaleItemRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
    }
}
