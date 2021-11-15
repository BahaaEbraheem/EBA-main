using FluentValidation;
using OA.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {

        public LoginRequestValidator()
        {
            //RuleFor(loginReq => loginReq.Email)
            //    .NotEmpty().WithMessage(Messages.REQUIRED)
            //    .EmailAddress().WithMessage(Messages.EMAIL);

            RuleFor(loginReq => loginReq.UserName)
                .NotEmpty().WithMessage(Messages.REQUIRED)
                .Must(Match.IsUserName).WithMessage(Messages.USERNAME);

            RuleFor(LoginReq => LoginReq.Password)
                .NotEmpty().WithMessage(Messages.REQUIRED);

        }

    }
}
