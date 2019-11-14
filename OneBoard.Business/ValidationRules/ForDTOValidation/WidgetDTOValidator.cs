using FluentValidation;
using OneBoard.Entities.DTO.Widget;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.ValidationRules.ForDTOValidation
{
   public class WidgetDTOValidator:AbstractValidator<WidgetDTO>
    {
        public WidgetDTOValidator()
        {
            RuleFor(w => w.PositionX)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(6);

            RuleFor(w => w.PositionY)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(3);

            RuleFor(w => w.Width)
                .LessThanOrEqualTo(6);

            RuleFor(w => w.Height)
                .LessThanOrEqualTo(3);

            RuleFor(w => w.Title).MinimumLength(5).MaximumLength(70);


        }
    }
}
