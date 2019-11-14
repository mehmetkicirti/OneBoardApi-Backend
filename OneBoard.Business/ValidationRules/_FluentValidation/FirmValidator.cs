using OneBoard.Entities.Concrete;
using FluentValidation;
using OneBoard.Core.Utilities.Constants;

namespace OneBoard.Business.ValidationRules._FluentValidation
{
    public class FirmValidator:AbstractValidator<Firm>
    {
       public FirmValidator()
       {

            RuleFor(f => f.FirmName)
                .MinimumLength(3)
                .MaximumLength(80)
                .NotNull()
                .NotEmpty();
                
                

           // RuleForEach(f => f.Groups)
               // .SetValidator(new GroupValidator());

           // RuleForEach(f => f.Dashboards).SetValidator(new DashboardValidator());

           // RuleForEach(f => f.UserFirms).SetValidator(new UserFirmValidator());

        }
    }
}
