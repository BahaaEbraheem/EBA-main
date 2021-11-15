using FluentValidation;
using OA.Domin.Administration;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.Validators
{
    public class CustomUserValidator : AbstractValidator<CustomUser>
    {

        public CustomUserValidator()
        {
            //RuleFor(user => user.Email)
            //    .NotEmpty().WithMessage(Messages.REQUIRED)
            //    .EmailAddress().WithMessage(Messages.EMAIL);

            RuleFor(user => user.UserName)
                .NotEmpty().WithMessage(Messages.REQUIRED)
                .Must(Match.IsUserName).WithMessage(Messages.USERNAME);

            When(user => string.IsNullOrEmpty(user.Id), () => {

                RuleFor(user => user.Password)
                    .NotEmpty().WithMessage(Messages.REQUIRED);

                RuleFor(user => user.ConfirmPassword)
                    .NotEmpty().WithMessage(Messages.REQUIRED)
                    .Matches(user => user.Password).WithMessage(Messages.PASSCONFIRM);

            });

            

        }

    }
}
