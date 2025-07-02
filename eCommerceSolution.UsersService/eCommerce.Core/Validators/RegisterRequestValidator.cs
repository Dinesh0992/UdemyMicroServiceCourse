

using eCommerce.Core.DTO;
using FluentValidation;
using System.Collections.Generic;
using System.ComponentModel;

namespace eCommerce.Core.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            //Email
            RuleFor(temp => temp.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email address format");

            //Password
            RuleFor(temp => temp.Password)
                .NotEmpty().WithMessage("Password is required")
                 .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                 .Matches(@"[!@#$%^&*(),.?"":{}\|<>]").WithMessage("Password must contain at least one special character.");

            //PersonName
            RuleFor(x => x.PersonName)
              .NotEmpty().WithMessage("PersonName must not be empty.")
              .Length(1, 50).WithMessage("PersonName should be between 1 and 50 characters long.");

            //Gender
            RuleFor(x => x.Gender)
                .IsInEnum().WithMessage("Invalid gender option")
                .Must(gender => Enum.IsDefined(typeof(GenderOptions), gender))
                .WithMessage("Gender must be one of the defined values in GenderOptions (Male, Female, Others).");

        }

    }
}
