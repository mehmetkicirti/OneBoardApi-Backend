using FluentValidation;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.ValidationRules._FluentValidation
{
    public class SerieValidator:AbstractValidator<Serie>
    {
        public SerieValidator()
        {
           // RuleFor(s => s.ChartType).SetValidator(new ChartTypeValidator());
           // RuleFor(s => s.DataSource).SetValidator(new DataSourceValidator());
           // RuleFor(s => s.Widget).SetValidator(new WidgetValidator());


            

        }
    }
}
