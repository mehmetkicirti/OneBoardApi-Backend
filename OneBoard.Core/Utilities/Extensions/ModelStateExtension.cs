using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace OneBoard.Core.Utilities.Extensions
{
    public static class ModelStateExtension
    {
        public static List<string> GetErrorMessage(this ModelStateDictionary dictionary)
        {
            //Firstly to get errors after that it is getting error message.
            return dictionary.SelectMany(m => m.Value.Errors).Select(x => x.ErrorMessage).ToList();
        }
    }
}
