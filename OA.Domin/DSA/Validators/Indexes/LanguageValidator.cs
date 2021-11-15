using FluentValidation;
using OA.Domin.DSA.Indexes;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators.Indexes
{
    public class LanguageValidator : AbstractValidator<Language>
    {

        public LanguageValidator()
        {
            RuleFor(job => job.Name_Ar).NotEmpty().WithMessage(Messages.REQUIRED);
        }

    }
}
