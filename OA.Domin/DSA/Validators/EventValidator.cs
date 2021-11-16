using FluentValidation;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators
{
    public class EventValidator : AbstractValidator<Event>
    {

        public EventValidator()
        {
            RuleFor(event1 => event1.Name).NotEmpty().WithMessage(Messages.REQUIRED);
            RuleFor(event1 => event1.EventCategoryId).NotNull().NotEqual(0).WithMessage(Messages.REQUIRED);
            RuleFor(event1 => event1.StartDate).NotNull().NotEqual(new DateTime()).WithMessage(Messages.REQUIRED);
            RuleFor(event1 => event1.EndDate).NotNull().NotEqual(new DateTime()).WithMessage(Messages.REQUIRED)
                                             .GreaterThan(event1 => event1.StartDate).WithMessage(Messages.NOTVALID);
            RuleFor(event1 => event1.Order).GreaterThan(0).WithMessage(Messages.NOTVALID);
        }

    }
}
