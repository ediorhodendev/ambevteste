namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Create
{
    public class CreateSaleItemRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}