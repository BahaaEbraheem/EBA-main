using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    class NewsTranslationValidator : AbstractValidator<NewsTranslation>
    {

        public NewsTranslationValidator()
        {
            RuleFor(eventTranslation => eventTranslation.Name).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(eventTranslation => eventTranslation.LanguageId).NotEmpty().WithMessage(Messages.REQUIRED);

            //RuleFor(eventTranslation => eventTranslation.Slug).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(eventTranslation => eventTranslation.NewsId).NotEqual(0).WithMessage(Messages.REQUIRED);
        }

    }
}
