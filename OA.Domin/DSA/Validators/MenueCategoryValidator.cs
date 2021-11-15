using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    public class MenueCategoryValidator : AbstractValidator<MenueCategory>
    {

        public MenueCategoryValidator()
        {
            RuleFor(menueCategory => menueCategory.Name).NotEmpty().WithMessage(Messages.REQUIRED);
        }

    }
}
