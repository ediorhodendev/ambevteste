namespace Ambev.DeveloperEvaluation.Application.Sales.Dtos;

public class SaleItemDto
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } // Descrição
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
}