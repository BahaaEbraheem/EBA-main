using FluentValidation;
using OA.Domin.DSA.Indexes;
using OA.Domin.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Validators.Indexes
{
    public class TrainingCourseTypeValidator : AbstractValidator<TrainingCourseType>
    {

        public TrainingCourseTypeValidator()
        {
            RuleFor(nat => nat.Name).NotEmpty().WithMessage(Messages.REQUIRED);
        }

    }
}
