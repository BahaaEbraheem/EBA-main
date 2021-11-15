using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    public class BlockValidator : AbstractValidator<Block>
    {

        public BlockValidator()
        {
            RuleFor(block => block.Name).NotEmpty().WithMessage(Messages.REQUIRED);            

            RuleFor(block => block.BlockCategoryId).NotEqual(0).WithMessage(Messages.REQUIRED);

            RuleFor(block => block.Order).GreaterThan(0).WithMessage(Messages.NOTVALID);

            RuleFor(block => block.BlockURL).NotEmpty().WithMessage(Messages.REQUIRED);
        }

    }
}
