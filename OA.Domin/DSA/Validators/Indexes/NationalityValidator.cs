using FluentValidation;
using OA.Domin.DSA.Indexes;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators.Indexes
{
    public class NationalityValidator : AbstractValidator<Nationality>
    {

        public NationalityValidator()
        {
            RuleFor(nat => nat.Code).NotEmpty().WithMessage(Messages.REQUIRED);
            RuleFor(nat => nat.Title_Ar).NotEmpty().WithMessage(Messages.REQUIRED);
           
        }

    }
}
