using FluentValidation;
using System;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Application.Customers.Validators
{
    public abstract class CustomerBaseValidator<T> : AbstractValidator<T> where T : class
    {
        protected void ApplyCustomerRules(
            Expression<Func<T, string>> nameSelector,
            Expression<Func<T, string>> emailSelector,
            Expression<Func<T, string>> phoneSelector)
        {
            RuleFor(nameSelector)
                .NotEmpty().WithMessage("O nome é obrigatório.");

            RuleFor(emailSelector)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("O e-mail informado é inválido.");

            RuleFor(phoneSelector)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\(?\d{2}\)?[\s-]?\d{4,5}-?\d{4}$")
                .WithMessage("O telefone informado é inválido. Use o formato (99) 99999-9999.");
        }
    }
}
