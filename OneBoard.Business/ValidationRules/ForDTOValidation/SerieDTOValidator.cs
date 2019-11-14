using FluentValidation;
using OneBoard.Entities.DTO.Serie;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.ValidationRules.ForDTOValidation
{
    public class SerieDTOValidator:AbstractValidator<SerieDTO>
    {
        public SerieDTOValidator()
        {
            //RuleFor(serie => serie.ChartTypeID).NotNull().NotEmpty();
            //RuleFor(serie => serie.DataSourceID).NotNull().NotEmpty();
            //RuleFor(serie => serie.WidgetID).NotNull().NotEmpty();
        }
    }
}
