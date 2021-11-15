//using FluentValidation;
//using OA.Domin.Validators;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace OA.Domin.DSA.Validators
//{
//    public class DonationValidator : AbstractValidator<Donation>
//    {

//        public DonationValidator()
//        {
//            When(donation => donation.PersonDonatorId == null, () =>
//            {
//                RuleFor(donation => donation.CorporateDonatorId).NotNull().WithMessage(Messages.REQUIRED);
//            })
//            .Otherwise(() => {
//                RuleFor(donation => donation.CorporateDonatorId).Null().WithMessage(Messages.NOTVALID);
//            });

//            When(donation => donation.CorporateDonatorId == null, () =>
//            {
//                RuleFor(donation => donation.PersonDonatorId).NotNull().WithMessage(Messages.REQUIRED);
//            })
//            .Otherwise(() => {
//                RuleFor(donation => donation.PersonDonatorId).Null().WithMessage(Messages.NOTVALID);
//            });

//            RuleFor(donation => donation.BeneficiaryId).NotNull().WithMessage(Messages.REQUIRED);

//            RuleFor(donation => donation.Date).NotEqual(new DateTime()).WithMessage(Messages.REQUIRED);

//            RuleFor(donation => donation.Amount).Must(Match.IsMony).WithMessage(Messages.MONY);


//        }

//    }
//}
