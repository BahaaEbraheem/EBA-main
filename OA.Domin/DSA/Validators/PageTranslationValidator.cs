using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    public class PageTranslationValidator : AbstractValidator<PageTranslation>
    {

        public PageTranslationValidator()
        {
            RuleFor(pageTranslation => pageTranslation.Name).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(pageTranslation => pageTranslation.LanguageId).NotEmpty().WithMessage(Messages.REQUIRED);


            RuleFor(pageTranslation => pageTranslation.HTMLContent).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(pageTranslation => pageTranslation.Link1).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(pageTranslation => pageTranslation.PageId).NotEqual(0).WithMessage(Messages.REQUIRED);
            
        }

    }
}
