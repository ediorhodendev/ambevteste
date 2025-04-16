namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Create
{
    public class CreateSaleRequest
    {
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public DateTime SaleDate { get; set; }
        public List<CreateSaleItemRequest> Items { get; set; } = new();
    }

}
