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
            RuleFor(nat => nat.Name).NotEmpty().WithMessage(Messages.REQUIRED);
        }

    }
}
