using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OneBoard.Business.ValidationRules.Model
{
    public static class SqlCommandValidator
    {
        private static Regex regex;

        
        private static bool SqlCommandValidatorByRegex(string input)
        {

            return regex.IsMatch(input) || regex.IsMatch(input.ToUpper()) || regex.IsMatch(input.ToLower());
        }


        public static bool SelectCommandValidatorByRegex(string input, string pattern = "SELECT")
        {
            regex = new Regex(@"" + pattern + ".*");
            return SqlCommandValidatorByRegex(input);
        }

        public static bool InsertCommandValidatorByRegex(string input)
        {

            regex = new Regex(@"[I||i]nsert.*");
            return SqlCommandValidatorByRegex(input);
        }





        //    public static bool TruncateSqlCommandValidatorByRegex(string input, string pattern = "TRUNCATE")
        //    {
        //        regex = new Regex(@"" + pattern + ".*");
        //        return SqlCommandValidatorByRegex(input);
        //    }


        //    public static bool CommitSqlCommandValidatorByRegex(string input,string pattern = "COMMIT")
        //    {
        //        regex = new Regex(@"" + pattern + ".*");
        //        return SqlCommandValidatorByRegex(input);
        //    }

        //    public static bool COMMİTSqlCommandValidatorByRegex(string input,string pattern = "COMMİT")
        //    {
        //        regex = new Regex(@"" + pattern + ".*");
        //        return SqlCommandValidatorByRegex(input);
        //    }

        //    public static bool commıtSqlCommandValidatorByRegex(string input,string pattern = "commıt")
        //    {
        //        regex = new Regex(@"" + pattern + ".*");
        //        return SqlCommandValidatorByRegex(input);
        //    }

        //    public static bool CreateSqlCommandValidatorByRegex(string input, string pattern = "CREATE")
        //    {
        //        regex = new Regex(@"" + pattern + ".*");
        //        return SqlCommandValidatorByRegex(input);
        //    }

        //    public static bool UpdateSqlCommandValidatorByRegex(string input, string pattern = "UPDATE")
        //    {
        //        regex = new Regex(@"" + pattern + ".*");
        //        return SqlCommandValidatorByRegex(input);
        //    }


        //    public static bool CommentSqlCommandValidatorByRegex(string input, string pattern = "COMMENT")
        //    {
        //        regex = new Regex(@"" + pattern + ".*");
        //        return SqlCommandValidatorByRegex(input);
        //    }

        //    public static bool AlterSqlCommandValidatorByRegex(string input, string pattern = "ALTER")
        //    {
        //        regex= new Regex(@"" + pattern + ".*");
        //        return SqlCommandValidatorByRegex(input);
        //    }

        //    public static bool RollBackSqlCommandValidatorByRegex(string input, string pattern = "ROLLBACK")
        //    {
        //        regex= new Regex(@"" + pattern + ".*");
        //        return SqlCommandValidatorByRegex(input);
        //    }

        //    public static bool DropSqlCommandValidatorByRegex(string input, string pattern = "DROP")
        //    {
        //        regex = new Regex(@"" + pattern + ".*");
        //        return SqlCommandValidatorByRegex(input);
        //    }

        //    public static bool DeleteSqlCommandValidatorByRegex(string input, string pattern = "DELETE")
        //    {
        //        regex = new Regex(@"" + pattern + ".*");
        //        return SqlCommandValidatorByRegex(input);
        //    }

        //    public static bool ModifySqlCommandValidatorByRegex(string input, string pattern = "Modify")
        //    {
        //        regex = new Regex(@"" + pattern + ".*");
        //        return SqlCommandValidatorByRegex(input);
        //    }

        //    public static bool ReplaceSqlCommandValidatorByRegex(string input, string pattern = "replace")
        //    {
        //        regex = new Regex(@"" + pattern + ".*");
        //        return SqlCommandValidatorByRegex(input);
        //    }

        //    public static bool SavePointSqlCommandValidatorByRegex(string input, string pattern = "SAVEPOINT")
        //    {
        //        regex = new Regex(@"" + pattern + ".*");
        //        return SqlCommandValidatorByRegex(input);
        //    }


    }
}
 