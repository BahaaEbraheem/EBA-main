using FluentValidation;
using OA.Domin.DSA;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {

        public PersonValidator()
        {
            RuleFor(nat => nat.Name).NotEmpty().WithMessage(Messages.REQUIRED);
            RuleFor(artCat => artCat.IdentificationNumber).NotEmpty().WithMessage(Messages.REQUIRED);
        }

    }
}
