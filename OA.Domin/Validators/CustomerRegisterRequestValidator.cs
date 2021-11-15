using FluentValidation;
using OA.Domin.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.Validators
{
    public class CustomerRegisterRequestValidator : AbstractValidator<CustomerRegisterRequest>
    {

        public CustomerRegisterRequestValidator()
        {
            RuleFor(custReg => custReg.UserName)
                .NotEmpty().WithMessage(Messages.REQUIRED)
                .Must(Match.IsUserName).WithMessage(Messages.USERNAME);

            //RuleFor(custReg => custReg.Email)
            //    .NotEmpty().WithMessage(Messages.REQUIRED)
            //    .EmailAddress().WithMessage(Messages.EMAIL);

            RuleFor(custReg => custReg.MobileNumber)
                .NotEmpty().WithMessage(Messages.REQUIRED)
                .Must(Match.IsMobile).WithMessage(Messages.MOBILE);
        }

    }
}
