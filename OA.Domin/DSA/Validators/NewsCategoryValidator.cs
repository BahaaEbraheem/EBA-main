using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    public class NewsCategoryValidator : AbstractValidator<NewsCategory>
    {

        public NewsCategoryValidator()
        {
            RuleFor(eventCategory => eventCategory.Name).NotEmpty().WithMessage(Messages.REQUIRED);


            RuleFor(eventCategory => eventCategory.Order).GreaterThan(0).WithMessage(Messages.NOTVALID);
        }

    }
}
