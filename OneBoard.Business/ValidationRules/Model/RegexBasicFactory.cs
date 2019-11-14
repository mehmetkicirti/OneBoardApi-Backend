using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OneBoard.Business.ValidationRules.Model
{
    public static class RegexBasicFactory
    {
        public static Regex CreateRegexInstance(string pattern)
        {
            return new Regex(pattern);
        }        
    }
}
