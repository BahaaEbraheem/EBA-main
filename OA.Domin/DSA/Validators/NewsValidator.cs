using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    public class NewsValidator : AbstractValidator<News>
    {

        public NewsValidator()
        {
            RuleFor(event1 => event1.Name_Ar).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(event1 => event1.NewsCategoryId).NotNull().NotEqual(0).WithMessage(Messages.REQUIRED);

            RuleFor(event1 => event1.AddedDate).NotNull().NotEqual(new DateTime()).WithMessage(Messages.REQUIRED);

            RuleFor(event1 => event1.EndDate).NotNull().NotEqual(new DateTime()).WithMessage(Messages.REQUIRED)
                                             .GreaterThan(event1 => event1.AddedDate).WithMessage(Messages.NOTVALID);

            RuleFor(event1 => event1.Order).GreaterThan(0).WithMessage(Messages.NOTVALID);
        }

    }
}
