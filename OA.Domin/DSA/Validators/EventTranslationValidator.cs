using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    class EventTranslationValidator : AbstractValidator<EventTranslation>
    {

        public EventTranslationValidator()
        {
            RuleFor(eventTranslation => eventTranslation.Name).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(eventTranslation => eventTranslation.LanguageId).NotEmpty().WithMessage(Messages.REQUIRED);

            //RuleFor(eventTranslation => eventTranslation.Slug).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(eventTranslation => eventTranslation.EventId).NotEqual(0).WithMessage(Messages.REQUIRED);
        }

    }
}
