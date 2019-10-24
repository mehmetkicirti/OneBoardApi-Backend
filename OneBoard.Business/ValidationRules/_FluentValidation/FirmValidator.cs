using OneBoard.Core.CrossCuttingCornces.Validation._FluentValidation;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using OneBoard.Core.Utilities.Constants;

namespace OneBoard.Business.ValidationRules._FluentValidation
{
    public class FirmValidator:AbstractValidator<Firm>
    {
       public FirmValidator()
       {
            RuleFor(f => f.FirmName).Must(f => f.StartsWith("K")).NotNull()
                .NotEqual("Koç").WithMessage(ValidationMessages.StartsWith+"\n"
                +ValidationMessages.NotNull+"\n"+ValidationMessages.NotEqual);
       }
    }
}
