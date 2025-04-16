using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.Create
{
    public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleCommandValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.BranchId).NotEmpty();
            RuleFor(x => x.SaleDate).NotEmpty();
            RuleForEach(x => x.Items).SetValidator(new CreateSaleItemDtoValidator());
        }
    }

    public class CreateSaleItemDtoValidator : AbstractValidator<CreateSaleItemDto>
    {
        public CreateSaleItemDtoValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.Quantity).GreaterThan(0).LessThanOrEqualTo(20);
            RuleFor(x => x.UnitPrice).GreaterThan(0);
        }
    }

}
