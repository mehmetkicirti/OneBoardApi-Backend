using OneBoard.Entities.Abstract;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Core.Utilities.Constants
{
    public static class ValidationMessages
    {

        public static string NotEmpty = "This Item can not be empty";
        public static string NotNull = "This Item can not be null";
        public static string MustBeThatRange = "This Item must be applied Interval";
        public static string GreaterThan = "This Item must be greater than applied value";
        public static string GreaterThanOrEqual = "This item must be greater than or equal to applied value";
        public static string NotEqual = "This Item can not be equal than applied value";
        public static string StartsWith = "This Item's starting must be applied value";
        public static string EndsWith = "This Item's ending must be applied value";

    }
}
