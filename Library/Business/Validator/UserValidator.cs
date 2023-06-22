using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validator
{
    public class UserValidator:AbstractValidator<User>,IUserValidator
    {
        public UserValidator()
        {
            RuleFor(r => r.Email).
                EmailAddress().WithMessage("Enter a valid email address")
                .NotEmpty().WithMessage("Email address cannot be empty");
            RuleFor(r => r.Name).
                NotEmpty().WithMessage("Name cannot be empty")
                .MaximumLength(100).WithMessage("Name length must be smaller than 250");
            RuleFor(r => r.Surname).
                NotEmpty().WithMessage("Name cannot be empty")
                .MaximumLength(100).WithMessage("Surname length must be smaller than 250");
            RuleFor(r => r.Password).
                NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(8).WithMessage("Password length must be bigger than 8").Must(ContainLetterCharacters)
            .WithMessage("Password must contain letter characters."); ;
        }
        private bool ContainLetterCharacters(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Any(char.IsLetter);
        }
    }
}
