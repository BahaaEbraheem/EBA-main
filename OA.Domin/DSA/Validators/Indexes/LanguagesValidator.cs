using FluentValidation;
using OA.Domin.DSA.Indexes;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators.Indexes
{
    public class LanguagesValidator : AbstractValidator<Language>
    {

        public LanguagesValidator()
        {
            RuleFor(nat => nat.Name).NotEmpty().WithMessage(Messages.REQUIRED);
            RuleFor(nat => nat.Slug).NotEmpty().WithMessage(Messages.REQUIRED);
        }

    }
}
