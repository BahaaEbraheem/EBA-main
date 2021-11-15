using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    class NewsCategoryTranslationValidator : AbstractValidator<NewsCategoryTranslation>
    {

        public NewsCategoryTranslationValidator()
        {
            RuleFor(eventCategoryTranslation => eventCategoryTranslation.Name).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(eventCategoryTranslation => eventCategoryTranslation.LanguageId).NotEmpty().WithMessage(Messages.REQUIRED);

            //RuleFor(eventCategoryTranslation => eventCategoryTranslation.Slug).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(eventCategoryTranslation => eventCategoryTranslation.NewsCategoryId).NotEqual(0).WithMessage(Messages.REQUIRED);
        }

    }
}
