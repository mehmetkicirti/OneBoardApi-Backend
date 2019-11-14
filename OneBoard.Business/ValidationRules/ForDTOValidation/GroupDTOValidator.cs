using FluentValidation;
using OneBoard.Entities.DTO.Group;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.ValidationRules.ForDTOValidation
{
    public class GroupDTOValidator:AbstractValidator<GroupDTO>
    {
        public GroupDTOValidator()
        {
            RuleFor(group => group.GroupName)
                .MinimumLength(3)
                .MaximumLength(80)
                .NotNull()
                .NotEmpty();
        }
    }
}
