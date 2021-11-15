using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    public class ArticleCategoryValidation : AbstractValidator<ArticleCategory>
    {
        public ArticleCategoryValidation()
        {
            RuleFor(artCat => artCat.Name).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(artCat => artCat.Type).NotEmpty().WithMessage(Messages.REQUIRED);
        }
    }
}
