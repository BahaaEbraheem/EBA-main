using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    public class NewCategoryValidator : AbstractValidator<NewCategory>
    {

        public NewCategoryValidator()
        {
            RuleFor(newCategory => newCategory.Name).NotEmpty().WithMessage(Messages.REQUIRED);


            //RuleFor(newCategory => newCategory.Order).GreaterThan(0).WithMessage(Messages.NOTVALID);
        }

    }
}
