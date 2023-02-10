using Business.Constants;
using Entities.Dtos.Examples;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.Examples
{
    public class ExampleUpdateValidator : AbstractValidator<ExampleUpdateDto>
    {
        public ExampleUpdateValidator()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage(Messages.ExampleNameNotEmpty);
            RuleFor(e => e.Name).NotNull();
            RuleFor(e => e.Name).MaximumLength(50).WithMessage(Messages.ExampleNameMaxLength);
            RuleFor(e => e.Description).NotEmpty().WithMessage(Messages.ExampleDescriptionNotEmpty);
            RuleFor(e => e.Description).NotNull();
            RuleFor(e => e.Description).MaximumLength(250).WithMessage(Messages.ExampleDescriptionMaxLength);
        }
    }
}
