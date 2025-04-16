using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.Update
{
    public class UpdateSaleItemDtoValidator : AbstractValidator<UpdateSaleItemDto>
    {
        public UpdateSaleItemDtoValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.Quantity).GreaterThan(0).LessThanOrEqualTo(20);
            RuleFor(x => x.UnitPrice).GreaterThan(0);
        }
    }
}
