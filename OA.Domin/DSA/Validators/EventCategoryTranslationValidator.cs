using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    class EventCategoryTranslationValidator : AbstractValidator<EventCategoryTranslation>
    {

        public EventCategoryTranslationValidator()
        {
            RuleFor(eventCategoryTranslation => eventCategoryTranslation.Name).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(eventCategoryTranslation => eventCategoryTranslation.LanguageId).NotEmpty().WithMessage(Messages.REQUIRED);


            RuleFor(eventCategoryTranslation => eventCategoryTranslation.EventCategoryId).NotEqual(0).WithMessage(Messages.REQUIRED);
        }

    }
}
