using FluentValidation;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.ValidationRules._FluentValidation
{
    public class DashboardValidator:AbstractValidator<Dashboard>
    {
        public DashboardValidator()
        {
            RuleFor(d => d.CreatorID).NotNull().NotEmpty();

           // RuleFor(d => d.Firm).SetValidator(new FirmValidator());
           // RuleFor(d => d.User).SetValidator(new UserValidator());
        }
    }
}
