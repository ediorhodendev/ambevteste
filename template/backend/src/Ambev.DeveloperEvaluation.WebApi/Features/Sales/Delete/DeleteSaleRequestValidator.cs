using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Delete
{
    public class DeleteSaleRequestValidator : AbstractValidator<DeleteSaleRequest>
    {
        public DeleteSaleRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
