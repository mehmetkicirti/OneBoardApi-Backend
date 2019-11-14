using FluentValidation;
using OneBoard.Entities.DTO.Dashboard;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.ValidationRules.ForDTOValidation
{
    public class DashboardDTOValidator:AbstractValidator<DashboardDTO>
    {
        public DashboardDTOValidator()
        {
           // RuleFor(dashboard => dashboard.CreatorID).NotNull().NotEmpty();
           // RuleFor(dashboard => dashboard.FirmID).NotNull().NotEmpty();
            
        }
    }
}
