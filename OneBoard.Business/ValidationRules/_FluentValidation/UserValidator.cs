using FluentValidation;
using OneBoard.Entities.Concrete;
using System.Text.RegularExpressions;
using OneBoard.Business.ValidationRules.Model;

namespace OneBoard.Business.ValidationRules._FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.UserName).NotEmpty().WithMessage("UserName never cannot be empty")
                .Length(2, 90).WithMessage("User name should be between 2 and 90 character.")
                .Custom((name,context)=>
                {
                    if (CommonValidator.NameValidatorByRegex(name))
                    {
                        context.AddFailure("User name should not take any number value");
                    }
            });

            RuleFor(u => u.LoginName).NotEmpty().WithMessage("Login Name never cannot be empty.").Length(2,90).WithMessage("Login name should be between 2 and 90 character.").Custom((loginName,context)=>
            {
                var arr = new[] { 1..9 };
                if (arr.ToString().Contains(loginName.Substring(0, 1)))
                {
                    context.AddFailure("Login name should not start with number");
                }
            });

            RuleFor(u => u.Password).NotEmpty().WithMessage("Password field cannot be empty").Length(8, 16).WithMessage("Password should be between 8 and 16 character.").Custom((pwd,context)=>
            {
                var arr = pwd.ToCharArray();
                foreach (char item in arr)
                {
                    if (CommonValidator.PasswordValidatorByRegex(item.ToString()))
                    {
                        context.AddFailure("Password at least 1 upper character.");
                    }
                }
            });

        }
    }
}
