using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    public class MenueValidator : AbstractValidator<Menue>
    {
        public MenueValidator()
        {
            RuleFor(menue => menue.Name).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(menue => menue.LevelOrder).NotNull().NotEqual(0).WithMessage(Messages.REQUIRED);

            RuleFor(menue => menue.PageUrl).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(menue => menue.Type).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(menue => menue.MenuCategoryId).NotNull().NotEqual(0).WithMessage(Messages.REQUIRED);
        }

    }
}
