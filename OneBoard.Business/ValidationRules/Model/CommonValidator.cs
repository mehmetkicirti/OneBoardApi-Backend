using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OneBoard.Business.ValidationRules.Model
{
    public static class CommonValidator
    {
        private static Regex regex;
        public static bool NameValidatorByRegex(string input, string pattern = @"^[a-zA-Z]*$")
        {
            regex = RegexBasicFactory.CreateRegexInstance(pattern);
            return regex.IsMatch(input);
        }

        public static bool PasswordValidatorByRegex(string input,string pattern= @"^[A-Z]*$")
        {
            regex = RegexBasicFactory.CreateRegexInstance(pattern);
            return regex.IsMatch(input);
        }

        
    }
}
