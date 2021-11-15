using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using OA.Domin.DSA.Indexes;

namespace OA.Domin.DSA.Validators.Indexes
{
    public class ChampionshipRankingValidator : AbstractValidator<ChampionshipRanking>
    {

        public ChampionshipRankingValidator()
        {
            RuleFor(gov => gov.Name_Ar).NotEmpty().WithMessage(Messages.REQUIRED);
        }

    }
}
