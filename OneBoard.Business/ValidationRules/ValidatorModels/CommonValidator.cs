using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OneBoard.Business.ValidationRules.ValidatorModels
{
    public static class CommonValidator
    {
        private static Regex regex;
        public static bool NameValidatorByRegex(string input)
        {
            regex = new Regex(@"^[a-zA-Z]*$");
            return regex.IsMatch(input);
        }

        public static bool PasswordValidatorByRegex(string input)
        {
            regex = new Regex("@^[A-Z]*$");
            return regex.IsMatch(input);
        }

        
    }
}
