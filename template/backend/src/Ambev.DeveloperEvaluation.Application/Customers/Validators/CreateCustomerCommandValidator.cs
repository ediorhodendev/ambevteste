using Ambev.DeveloperEvaluation.Application.Customers.Create;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.Validators
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("E-mail inválido.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\(?\d{2}\)?[\s-]?\d{4,5}-?\d{4}$")
                .WithMessage("Telefone inválido. Ex: (11) 99999-9999");
        }
    }

}
