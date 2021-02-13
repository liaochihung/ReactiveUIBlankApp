using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace LoginModule.ViewModels
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(l => l.User)
                .NotEmpty()
                .WithMessage("Please specify a Name.");

            RuleFor(l => l.Password)
                .NotEmpty()
                .Length(3, 20)
                .WithMessage("Please specify a Password.");
        }
    }
}
