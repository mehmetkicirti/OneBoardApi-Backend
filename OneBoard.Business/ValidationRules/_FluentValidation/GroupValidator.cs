using FluentValidation;
using OneBoard.Entities.Concrete;

namespace OneBoard.Business.ValidationRules._FluentValidation
{
    public class GroupValidator:AbstractValidator<Group>
    {
        public GroupValidator()
        {
            RuleFor(g => g.Firm)
                .SetValidator(new FirmValidator());


            RuleFor(g => g.GroupName)
                .NotNull()
                .Must(groupname => groupname.Contains("Grup") | groupname.Contains("Holding"))
                .WithMessage("Error");


        }
    }
}
