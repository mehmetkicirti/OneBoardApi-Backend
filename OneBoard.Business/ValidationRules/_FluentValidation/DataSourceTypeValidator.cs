using FluentValidation;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.ValidationRules._FluentValidation
{
  public class DataSourceTypeValidator:AbstractValidator<DataSourceType>
    {
        public DataSourceTypeValidator()
        {
            //RuleForEach(dataSourceType => dataSourceType.DataSources).SetValidator(new DataSourceValidator());

            //RuleFor(dataSourceType => dataSourceType.ID)
                //.NotNull();
                
            

            
        }
    }
}
