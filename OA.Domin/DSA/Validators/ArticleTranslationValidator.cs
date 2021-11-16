using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    public class ArticleTranslationValidator : AbstractValidator<ArticleTranslation>
    {
        public ArticleTranslationValidator()
        {
            RuleFor(artCat => artCat.Name).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(artCat => artCat.LanguageId).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(artCat => artCat.Content).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(artCat => artCat.ArticleId).NotEqual(0).WithMessage(Messages.REQUIRED);
            
        }
    }
}
