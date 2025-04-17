using Ambev.DeveloperEvaluation.Application.Customers.Update;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.Validators
{
    public class UpdateCustomerCommandValidator : CustomerBaseValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            ApplyCustomerRules(
                x => x.Name,
                x => x.Email,
                x => x.Phone
            );
        }
    }
}
