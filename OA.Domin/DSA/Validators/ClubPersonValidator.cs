using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    public class ClubPersonValidator : AbstractValidator<ClubPerson>
    {

        public ClubPersonValidator()
        {
            When(x => x.ClubId == null, () =>
            {
                RuleFor(x => x.ClubId).NotNull().WithMessage(Messages.REQUIRED);
            })
            .Otherwise(() =>
            {
                RuleFor(x => x.ClubId).Null().WithMessage(Messages.NOTVALID);
            });

            When(x => x.PersonId == null, () =>
            {
                RuleFor(x => x.PersonId).NotNull().WithMessage(Messages.REQUIRED);
            })
            .Otherwise(() =>
            {
                RuleFor(x => x.PersonId).Null().WithMessage(Messages.NOTVALID);
            });

            //RuleFor(x => x.).NotNull().WithMessage(Messages.REQUIRED);

            //RuleFor(x => x.Date).NotEqual(new DateTime()).WithMessage(Messages.REQUIRED);

            //RuleFor(x => x.Amount).Must(Match.IsMony).WithMessage(Messages.MONY);


        }

    }
}
