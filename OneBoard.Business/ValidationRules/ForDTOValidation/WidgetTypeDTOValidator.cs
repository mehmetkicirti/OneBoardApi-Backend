using FluentValidation;
using OneBoard.Entities.DTO.WidgetType;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.ValidationRules.ForDTOValidation
{
    public class WidgetTypeDTOValidator:AbstractValidator<WidgetTypeDTO>
    {
        public WidgetTypeDTOValidator()
        {
            
        }
    }
}
