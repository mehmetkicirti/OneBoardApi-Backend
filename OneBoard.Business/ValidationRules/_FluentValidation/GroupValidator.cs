using FluentValidation;
using OneBoard.Entities.Concrete;

namespace OneBoard.Business.ValidationRules._FluentValidation
{
    public class GroupValidator:AbstractValidator<Group>
    {
        public GroupValidator()
        {
           // RuleFor(g => g.Firm)
               // .SetValidator(new FirmValidator());

           // RuleForEach(g => g.UserGroups)
              //  .SetValidator(new UserGroupValidator());

            

            RuleFor(g => g.GroupName)
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(70);

            
                


        }
    }
}
