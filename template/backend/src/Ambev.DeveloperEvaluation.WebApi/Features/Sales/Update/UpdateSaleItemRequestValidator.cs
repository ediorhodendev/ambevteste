using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Update
{
    public class UpdateSaleItemRequestValidator : AbstractValidator<UpdateSaleItemRequest>
    {
        public UpdateSaleItemRequestValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.Quantity).GreaterThan(0).LessThanOrEqualTo(20);
            RuleFor(x => x.UnitPrice).GreaterThan(0);
        }
    }
}
