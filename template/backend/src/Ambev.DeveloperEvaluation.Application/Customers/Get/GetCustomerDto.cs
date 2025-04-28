using System;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetAll
{
    public class GetCustomerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        // Adicione aqui outros campos que seu CustomerEntity tenha
    }
}
