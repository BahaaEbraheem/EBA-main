using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    class NewCategoryTranslationValidator : AbstractValidator<NewCategoryTranslation>
    {

        public NewCategoryTranslationValidator()
        {
            RuleFor(newCategoryTranslation => newCategoryTranslation.Name).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(newCategoryTranslation => newCategoryTranslation.LanguageId).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(newCategoryTranslation => newCategoryTranslation.NewCategoryId).NotEqual(0).WithMessage(Messages.REQUIRED);
        }

    }
}
