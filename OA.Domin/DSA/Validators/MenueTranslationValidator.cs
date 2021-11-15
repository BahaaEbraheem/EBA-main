using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    class MenueTranslationValidator : AbstractValidator<MenueTranslation>
    {

        public MenueTranslationValidator()
        {
            RuleFor(menueTranslation => menueTranslation.Name).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(menueTranslation => menueTranslation.LanguageId).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(menueTranslation => menueTranslation.HTMLContent).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(menueTranslation => menueTranslation.MenueId).NotEqual(0).WithMessage(Messages.REQUIRED);
        }

    }
}
