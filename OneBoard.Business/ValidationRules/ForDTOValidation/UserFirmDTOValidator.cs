using FluentValidation;
using OneBoard.Entities.DTO.UserFirm;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.ValidationRules.ForDTOValidation
{
    public class UserFirmDTOValidator:AbstractValidator<UserFirmDTO>
    {
        public UserFirmDTOValidator()
        {
            //RuleFor(userFirm => userFirm.FirmID).NotNull().NotEmpty();
            //RuleFor(userFirm => userFirm.UserID).NotNull().NotEmpty();
        }
    }
}
