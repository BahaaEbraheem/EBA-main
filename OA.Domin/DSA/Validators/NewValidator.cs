using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    public class NewValidator : AbstractValidator<New>
    {

        public NewValidator()
        {
            RuleFor(new1 => new1.Name).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(new1 => new1.NewCategoryId).NotNull().NotEqual(0).WithMessage(Messages.REQUIRED);

            RuleFor(new1 => new1.StartDate).NotNull().NotEqual(new DateTime()).WithMessage(Messages.REQUIRED);

            RuleFor(new1 => new1.EndDate).NotNull().NotEqual(new DateTime()).WithMessage(Messages.REQUIRED)
                                             .GreaterThan(event1 => event1.StartDate).WithMessage(Messages.NOTVALID);

            RuleFor(new1 => new1.Order).GreaterThan(0).WithMessage(Messages.NOTVALID);
        }

    }
}
