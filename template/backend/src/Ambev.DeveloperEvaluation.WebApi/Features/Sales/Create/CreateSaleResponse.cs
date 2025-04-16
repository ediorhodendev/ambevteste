namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Create
{
    public class CreateSaleResponse
    {
        public Guid SaleId { get; set; }
        public decimal Total { get; set; }
        public bool Cancelled { get; set; }
    }
}
