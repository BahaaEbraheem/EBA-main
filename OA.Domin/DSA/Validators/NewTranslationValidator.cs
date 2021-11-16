using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    class NewTranslationValidator : AbstractValidator<NewTranslation>
    {

        public NewTranslationValidator()
        {
            RuleFor(newTranslation => newTranslation.Name).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(newTranslation => newTranslation.LanguageId).NotEmpty().WithMessage(Messages.REQUIRED);
            RuleFor(newTranslation => newTranslation.HTMLContent).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(newTranslation => newTranslation.NewId).NotEqual(0).WithMessage(Messages.REQUIRED);
        }

    }
}
