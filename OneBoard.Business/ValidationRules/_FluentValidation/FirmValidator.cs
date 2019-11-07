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
                .NotNull()
                .NotEmpty()
                .WithMessage("Error");

            //RuleFor(f => f.Groups).SetValidator(new GroupValidator())
                

        }
    }
}
