using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    class BlockTranslationValidator : AbstractValidator<BlockTranslation>
    {

        public BlockTranslationValidator()
        {
            RuleFor(blockTranslation => blockTranslation.Name).NotEmpty().WithMessage(Messages.REQUIRED);

            RuleFor(blockTranslation => blockTranslation.LanguageId).NotEmpty().WithMessage(Messages.REQUIRED);


            RuleFor(blockTranslation => blockTranslation.BlockId).NotEqual(0).WithMessage(Messages.NOTVALID);
        }

    }
}
