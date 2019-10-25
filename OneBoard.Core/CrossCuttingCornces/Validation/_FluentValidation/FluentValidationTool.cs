using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using OneBoard.Core.Utilities.Results.Concerete.Result;

namespace OneBoard.Core.CrossCuttingCornces.Validation._FluentValidation
{
    public static class FluentValidationTool
    {
        public static void Validate(IValidator validator,object entity)
        {
            var result = validator.Validate(entity);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors[0].ErrorMessage);
            }
        }
    }
}
