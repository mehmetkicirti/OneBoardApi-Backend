using FluentValidation;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.ValidationRules._FluentValidation
{
   public class UserFirmValidator:AbstractValidator<UserFirm>
    {
        public UserFirmValidator()
        {
           // RuleFor(uf => uf.User).SetValidator(new UserValidator());
           // RuleFor(uf => uf.Firm).SetValidator(new FirmValidator());

            //RuleFor(uf => uf.FirmID).NotNull();
            //RuleFor(uf => uf.UserID).NotNull();
        }
    }
}
