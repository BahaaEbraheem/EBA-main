using FluentValidation;
using OA.Domin.DSA;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    public class PTypeValidator : AbstractValidator<PType>
    {

        public PTypeValidator()
        {
            RuleFor(nat => nat.Name).NotEmpty().WithMessage(Messages.REQUIRED);
        }

    }
}
