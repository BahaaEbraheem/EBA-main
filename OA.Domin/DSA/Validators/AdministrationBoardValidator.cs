using FluentValidation;
using OA.Domin.DSA;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    public class AdministrationBoardValidator : AbstractValidator<AdministrationBoard>
    {

        public AdministrationBoardValidator()
        {
            //RuleFor(nat => nat.Person.Name).NotEmpty().WithMessage(Messages.REQUIRED);
            //RuleFor(artCat => artCat.Person.IdentificationNumber).NotEmpty().WithMessage(Messages.REQUIRED);


        }

 


    }
}
