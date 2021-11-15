using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    public class BlockCategoryValidator : AbstractValidator<BlockCategory>
    {
        public BlockCategoryValidator()
        {

            RuleFor(blockCategory => blockCategory.Name).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(blockCategory => blockCategory.Type).NotEmpty().WithMessage(Messages.REQUIRED);

        }

    }
}
