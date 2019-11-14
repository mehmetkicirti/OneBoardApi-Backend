using FluentValidation;
using OneBoard.Entities.Concrete;
using OneBoard.Entities.DTO.DataSourceType;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.ValidationRules.ForDTOValidation
{
    public class DataSourceTypeDTOValidator:AbstractValidator<DataSourceTypeDTO>
    {
        public DataSourceTypeDTOValidator()
        {
           
        }
    }
}
