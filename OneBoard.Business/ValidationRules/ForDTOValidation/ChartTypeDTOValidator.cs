﻿using FluentValidation;
using OneBoard.Entities.DTO.ChartType;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.ValidationRules.ForDTOValidation
{
    public class ChartTypeDTOValidator:AbstractValidator<ChartTypeDTO>
    {
        public ChartTypeDTOValidator()
        {
           
        }
    }
}
