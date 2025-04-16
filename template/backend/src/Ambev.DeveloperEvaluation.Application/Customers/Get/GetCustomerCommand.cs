using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.Get
{
    public class GetCustomerCommand : IRequest<GetCustomerResult?>
    {
        public Guid Id { get; set; }
    }
}
