using FluentValidation;
using OneBoard.Entities.DTO.DataSource;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OneBoard.Business.ValidationRules.ForDTOValidation
{
   public class DataSourceDTOValidator:AbstractValidator<DataSourceDTO>
    {
        public DataSourceDTOValidator()
        {
            #region Regular Expressions
            Regex DELETERegex = new Regex(@"DELETE.*");
            Regex deleteRegex = new Regex(@"delete.*");

            Regex ALTERRegex = new Regex(@"ALTER.*");
            Regex alterRegex = new Regex(@"alter.*");
          
            Regex TRUNCATERegex = new Regex(@"TRUNCATE.*");
            Regex truncateRegex = new Regex(@"truncate.*");


            Regex CREATERegex = new Regex(@"CREATE.*");
            Regex createRegex = new Regex(@"create.*");

            Regex UPDATERegex = new Regex(@"UPDATE.*");
            Regex updateRegex = new Regex(@"update.*");

            Regex COMMENTRegex = new Regex(@"COMMENT.*");
            Regex commentRegex = new Regex(@"comment.*");

            Regex COMMITRegex = new Regex(@"COMMIT.*");
            Regex commitRegex = new Regex(@"commit.*");

            Regex ROLLBACK = new Regex(@"ROLLBACK.*");
            Regex rollback = new Regex(@"rollback.*");

            Regex SAVEPOINT = new Regex(@"SAVEPOINT.*");
            Regex savepoint = new Regex(@"savepoint.*");


            Regex DROPRegex = new Regex(@"DROP.*");
            Regex dropRegex = new Regex(@"drop.*");

            Regex INSERTRegex = new Regex(@"INSERT.*");
            Regex insertRegex = new Regex(@"insert.*");

            Regex SELECTRegex = new Regex(@"SELECT.*");
            Regex selectRegex = new Regex(@"select.*");

            Regex ModifyRegex = new Regex(@"Modify.*");
            Regex UpdateRegex = new Regex(@"Update.*");
            Regex DeleteRegex = new Regex(@"Delete.*");

            #endregion




  
         

            #region QueryStringRules
            RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            {
                if (CREATERegex.IsMatch(queryString) || CREATERegex.IsMatch(queryString.ToUpper()))
                {
                    context.AddFailure("You have not authenticate to using Create command");
                }

                else if (createRegex.IsMatch(queryString) || createRegex.IsMatch(queryString.ToLower()))
                {
                    context.AddFailure("You have not authenticate to using Create command");
                }
               
            });

            RuleFor(dataSource=>dataSource.QueryString).Custom((queryString, context) =>
            {
                if (TRUNCATERegex.IsMatch(queryString) || TRUNCATERegex.IsMatch(queryString.ToUpper()))
                {
                    context.AddFailure("You have not authenticate to using Truncate command");
                }

                else if (truncateRegex.IsMatch(queryString) || truncateRegex.IsMatch(queryString.ToLower()))
                {
                    context.AddFailure("You have not authenticate to using Truncate command");
                }

            });

            RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            {
                if (ALTERRegex.IsMatch(queryString) || ALTERRegex.IsMatch(queryString.ToUpper()))
                {
                    context.AddFailure("You have not authenticate to using Alter command");
                }


                else if (alterRegex.IsMatch(queryString) || alterRegex.IsMatch(queryString.ToLower()))
                {
                    context.AddFailure("You have not authenticate to using Alter command");
                }

            });

            RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            {
                if (DELETERegex.IsMatch(queryString) || DELETERegex.IsMatch(queryString.ToUpper()))
                {
                    context.AddFailure("You have not authenticate to using Delete command");
                }

                else if (deleteRegex.IsMatch(queryString) || deleteRegex.IsMatch(queryString.ToLower()))
                {
                    context.AddFailure("You have not authenticate to using Delete command");
                }

            });

            RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            {
                
                if (UPDATERegex.IsMatch(queryString) || UPDATERegex.IsMatch(queryString.ToUpper()))
                {
                    context.AddFailure("You have not authenticate to using Update command");
                }

                else if (updateRegex.IsMatch(queryString) || updateRegex.IsMatch(queryString.ToLower()))
                {
                    context.AddFailure("You have not authenticate to using Update command");
                }

            });

            RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            {
                if (COMMITRegex.IsMatch(queryString) || COMMITRegex.IsMatch(queryString.ToUpper()))
                {
                    context.AddFailure("You have not authenticate to using Commit command");
                }

                else if (commitRegex.IsMatch(queryString) || commitRegex.IsMatch(queryString.ToLower()))
                {
                    context.AddFailure("You have not authenticate to using Commit command");
                }

            });

            RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            {
                if (SAVEPOINT.IsMatch(queryString) || SAVEPOINT.IsMatch(queryString.ToUpper()))
                {
                    context.AddFailure("You have not authenticate to using Savepoint command");
                }

                else if (savepoint.IsMatch(queryString) || savepoint.IsMatch(queryString.ToLower()))
                {
                    context.AddFailure("You have not authenticate to using Savepoint command");
                }

            });

            RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            {
                if (ROLLBACK.IsMatch(queryString) || ROLLBACK.IsMatch(queryString.ToUpper()))
                {
                    context.AddFailure("You have not authenticate to using Rollback command");
                }

                else if (rollback.IsMatch(queryString) || rollback.IsMatch(queryString.ToLower()))
                {
                    context.AddFailure("You have not authenticate to using Rollback command");
                }

            });

            RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            {
                if (DROPRegex.IsMatch(queryString) || DROPRegex.IsMatch(queryString.ToUpper()))
                {
                    context.AddFailure("You have not authenticate to using Drop command");
                }

                else if (dropRegex.IsMatch(queryString) || dropRegex.IsMatch(queryString.ToLower()))
                {
                    context.AddFailure("You have not authenticate to using Drop command");
                }

            });

            RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            {
                if (DeleteRegex.IsMatch(queryString))
                {
                    context.AddFailure("You have not authenticate to using Delete command");
                }
            });

            RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            {
                if (ModifyRegex.IsMatch(queryString))
                {
                    context.AddFailure("You have not authenticate to using Modify command");
                }
            });

            RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            {
                if (UpdateRegex.IsMatch(queryString))
                {
                    context.AddFailure("You have not authenticate to using Update command");
                }
            });






            #endregion


            #region ConnectionStringRules

            RuleFor(d => d.ConnString)
           .Must(connectionString => connectionString.StartsWith("Data Source=") || connectionString.StartsWith("Server="))
           .Must(connectionString => connectionString.EndsWith(';'))
           .Matches(".*;")
           .When(d => d.DataSourceTypeID == 13);
            // MSSQL Server Connection String Rules

            RuleFor(d => d.ConnString)
            .Must(connectionString => connectionString.StartsWith("Data Source="))
            .Must(connectionString => connectionString.EndsWith(';'))
            .Matches(".*;")
            .When(d => d.DataSourceTypeID == 14);

            //Oracle Connection String Rules


            RuleFor(d => d.ConnString)
                .Must(connectionString => connectionString.StartsWith("Provider="))
                .Must(connectionString => connectionString.EndsWith(';'))
                .Matches(".*;")
                .Matches(".*Data Source=")
                .When(d => d.DataSourceTypeID == 19);
            ////MS Access Connection String Rules

            RuleFor(d => d.ConnString)
                .Must(connectionString => connectionString.StartsWith("Server="))
                .Matches(".*;")
                .Matches(".*;Database=")
                .Matches(".*;Uid=")
                .Matches(".*;Pwd=")
                .Must(connectionString => connectionString.EndsWith(';'))
               .When(d => d.DataSourceTypeID == 15);
            ////MySQL Connection String Rules

            RuleFor(d => d.ConnString).Must(connectionString =>
             connectionString.StartsWith("Excel File="))
                .When(d => d.DataSourceTypeID == 12);
            ////Excel Connection String Rules


            RuleFor(d => d.ConnString)
                .Must(connectionString => connectionString.StartsWith("mongodb://"))
                .When(d => d.DataSourceTypeID == 17);

            //MongoDb Connection String Rules

            RuleFor(d => d.ConnString).Must(connectionString => connectionString.StartsWith("User ID=") | connectionString.StartsWith("Provider=")
            | connectionString.StartsWith("Server="))
            .Matches(".*;")
            .Must(connectionString => connectionString.EndsWith(';'))
            .When(d => d.DataSourceTypeID == 16);
            //PostgreSQL Connection String Rules


            RuleFor(d => d.ConnString).Must(connectionString => connectionString.StartsWith("Server="))
                .Matches(".*;")
                .Matches(".*;Database=")
                .Matches(".*;UID=")
                .Matches(".*;PWD=")
                .Must(connectionString => connectionString.EndsWith(';'))
                .When(d => d.DataSourceTypeID == 20);
            //IBMDB2 Connection String Rules

            RuleFor(d => d.ConnString).Must(connectionString => connectionString.StartsWith("Data Source="))
                .Matches(".*;Version=")
                .Matches(".*;")
                .Must(connectionString => connectionString.EndsWith(';'))
                .When(d => d.DataSourceTypeID == 18);
            //SQLlite connection string rules

            #endregion










        }
    }
}
