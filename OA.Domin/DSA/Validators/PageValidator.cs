using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    public class PageValidator : AbstractValidator<Page>
    {

        public PageValidator()
        {
            RuleFor(page => page.Name).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(page => page.Type).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(page => page.Order).GreaterThan(0).WithMessage(Messages.REQUIRED);
        }

    }
}
