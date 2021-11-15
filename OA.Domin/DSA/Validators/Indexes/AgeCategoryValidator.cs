using FluentValidation;
using OA.Domin.DSA.Indexes;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators.Indexes
{
    public class AgeCategoryValidator : AbstractValidator<AgeCategory>
    {

        public AgeCategoryValidator()
        {
            RuleFor(act => act.Name_Ar).NotEmpty().WithMessage(Messages.REQUIRED);
        }

    }
}
