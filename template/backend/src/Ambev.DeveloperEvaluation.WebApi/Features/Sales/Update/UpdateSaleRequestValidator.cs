using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Update
{
    public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
    {
        public UpdateSaleRequestValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.BranchId).NotEmpty();
            RuleForEach(x => x.Items).SetValidator(new UpdateSaleItemRequestValidator());
        }
    }
}
