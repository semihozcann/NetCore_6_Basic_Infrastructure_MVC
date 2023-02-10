using Business.Constants;
using Core.Entities.Concrete;
using Entities.Dtos.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.Users
{
    public class AuthRegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public AuthRegisterValidator()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage(Messages.MailNotEmpty);
            RuleFor(u => u.Email).NotNull();
            RuleFor(u => u.Email).MaximumLength(150).WithMessage(Messages.EmailTooLong);
            RuleFor(u => u.FirstName).NotEmpty().WithMessage(Messages.FirstNameNotEmpty);
            RuleFor(u => u.FirstName).NotNull();
            RuleFor(u => u.FirstName).MaximumLength(50).WithMessage(Messages.FirstNameTooLong);
            RuleFor(u => u.LastName).NotEmpty().WithMessage(Messages.LastNameNotEmpty);
            RuleFor(u => u.LastName).NotNull();
            RuleFor(u => u.LastName).MaximumLength(100).WithMessage(Messages.LastNameTooLong);
        }
    }
}
