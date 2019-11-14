using FluentValidation;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.ValidationRules._FluentValidation
{
    public class ChartTypeValidator:AbstractValidator<ChartType>
    {
        public ChartTypeValidator()
        {
            //RuleForEach(chartType => chartType.Series).SetValidator(new SerieValidator());

            
        }
    }
}
