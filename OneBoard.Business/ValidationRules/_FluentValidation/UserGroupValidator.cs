using FluentValidation;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.ValidationRules._FluentValidation
{
    public class UserGroupValidator:AbstractValidator<UserGroup>
    {
        public UserGroupValidator()
        {
            //RuleFor(ug => ug.Group).SetValidator(new GroupValidator());
           // RuleFor(ug => ug.User).SetValidator(new UserValidator());

            //RuleFor(ug => ug.GroupID).NotNull();
            //RuleFor(ug => ug.UserID).NotNull();
           
        }
    }
}
