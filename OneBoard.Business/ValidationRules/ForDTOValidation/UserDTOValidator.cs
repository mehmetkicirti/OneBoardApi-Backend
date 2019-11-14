using FluentValidation;
using OneBoard.Entities.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OneBoard.Business.ValidationRules.ForDTOValidation
{
  public class UserDTOValidator:AbstractValidator<UserDTO>
    {
        Regex rName = new Regex(@"^[a-zA-Z]*$");
        Regex rPassword = new Regex(@"^[A-Z]*$");
        public UserDTOValidator()
        {

            RuleFor(u => u.UserName).NotEmpty().WithMessage("UserName never cannot be empty")
               .Length(2, 90).WithMessage("User name should be between 2 and 90 character.")
               .Custom((name, context) =>
               {
                   if (rName.IsMatch(name))
                   {
                       context.AddFailure("User name should not take any number value");
                   }
               });


            RuleFor(u => u.LoginName).NotEmpty().WithMessage("Login Name never cannot be empty.").Length(2, 90).WithMessage("Login name should be between 2 and 90 character.").Custom((loginName, context) =>
            {
                var arr = new[] { 1..9 };
                if (!arr.ToString().Contains(loginName.Substring(0, 1)))
                {
                    context.AddFailure("Login name should not start with number");
                }
            }).NotEqual(u => u.UserName);

            RuleFor(u => u.Password).NotEmpty().WithMessage("Password field cannot be empty").Length(8, 16).WithMessage("Password should be between 8 and 16 character.").Custom((pwd, context) =>
            {
                var arr = pwd.ToCharArray();
                foreach (char item in arr)
                {
                    if (!rPassword.IsMatch(item.ToString()))
                    {
                        context.AddFailure("Password at least 1 upper character.");
                    }
                }
            });

            



        }
    }
}
