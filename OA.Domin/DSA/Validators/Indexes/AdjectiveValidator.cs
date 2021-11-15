using FluentValidation;
using OA.Domin.DSA.Indexes;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators.Indexes
{
    public class AdjectiveValidator : AbstractValidator<Adjective>
    {

        public AdjectiveValidator()
        {
            RuleFor(qual => qual.Name_Ar).NotEmpty().WithMessage(Messages.REQUIRED);
        }

    }
}
