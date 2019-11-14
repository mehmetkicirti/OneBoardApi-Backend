using FluentValidation;
using OneBoard.Entities.Concrete;
using OneBoard.Entities.DTO.UserGroup;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.ValidationRules.ForDTOValidation
{
    public class UserGroupDTOValidator:AbstractValidator<UserGroupDTO>
    {
        public UserGroupDTOValidator()
        {
            //RuleFor(userGroup => userGroup.GroupID).NotNull().NotEmpty();
            //RuleFor(userGroup=>userGroup.UserID).NotNull().NotEmpty();
        }
    }
}
