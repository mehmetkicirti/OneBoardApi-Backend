using FluentValidation;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.ValidationRules._FluentValidation
{
   public class WidgetValidator:AbstractValidator<Widget>
    {
        public WidgetValidator()
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
