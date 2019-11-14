using FluentValidation;
using OneBoard.Entities.DTO.Firm;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.ValidationRules.ForDTOValidation
{
   public class FirmDTOValidator:AbstractValidator<FirmDTO>
    {

        public FirmDTOValidator()
        {
            RuleFor(firm => firm.FirmName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(80);
        }
    }
}
