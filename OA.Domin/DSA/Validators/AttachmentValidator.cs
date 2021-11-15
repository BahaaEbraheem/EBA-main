using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    public class AttachmentValidator : AbstractValidator<Attachment>
    {

        public AttachmentValidator()
        {
            RuleFor(att => att.Name).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(att => att.Type).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(att => att.Reference).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(att => att.ReferenceId).NotEqual(0).WithMessage(Messages.REQUIRED);

            RuleFor(att => att.File).NotNull().WithMessage(Messages.REQUIRED);

        }

    }
}
