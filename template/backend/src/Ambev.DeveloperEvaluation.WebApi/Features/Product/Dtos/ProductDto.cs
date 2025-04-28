using System;

namespace Ambev.DeveloperEvaluation.Application.Products.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        // Adicione mais campos se seu Product tiver
    }
}
