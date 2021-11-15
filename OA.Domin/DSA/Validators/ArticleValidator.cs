using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(art => art.Name).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(art => art.Order).NotEqual(0).WithMessage(Messages.NOTVALID);

            RuleFor(art => art.Date).NotEqual(new DateTime()).WithMessage(Messages.REQUIRED);

            RuleFor(art => art.Content).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(art => art.ArticleCategoryId).NotEqual(0).WithMessage(Messages.REQUIRED);
        }
    }
}
