namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.Get
{
    public class GetCustomerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
