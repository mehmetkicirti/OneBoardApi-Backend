using FluentValidation;
using OneBoard.Business.ValidationRules.Model;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OneBoard.Business.ValidationRules._FluentValidation
{
    public class DataSourceValidator:AbstractValidator<DataSource>
    {
       

        
        public DataSourceValidator()
        {
            #region ConnectionStringRules

            RuleFor(d => d.ConnString)
             .Must(connectionString => connectionString.StartsWith("Data Source=")||connectionString.StartsWith("Server="))
             .Must(connectionString=>connectionString.EndsWith(';'))
             .Matches(".*;")
             .When(d => d.DataSourceTypeID==13);
            // MSSQL Server Connection String Rules

            RuleFor(d => d.ConnString)
            .Must(connectionString => connectionString.StartsWith("Data Source="))
            .Must(connectionString => connectionString.EndsWith(';'))
            .Matches(".*;")
            .When(d => d.DataSourceTypeID == 14);

            //Oracle Connection String Rules


            RuleFor(d => d.ConnString)
                .Must(connectionString =>connectionString.StartsWith("Provider="))
                .Must(connectionString=>connectionString.EndsWith(';'))
                .Matches(".*;")
                .Matches(".*Data Source=")
                .When(d => d.DataSourceTypeID == 19);     
            ////MS Access Connection String Rules

            RuleFor(d => d.ConnString)
                .Must(connectionString =>connectionString.StartsWith("Server="))
                .Matches(".*;")
                .Matches(".*;Database=")
                .Matches(".*;Uid=")
                .Matches(".*;Pwd=")
                .Must(connectionString=>connectionString.EndsWith(';'))
               .When(d => d.DataSourceTypeID==15);
            ////MySQL Connection String Rules

            RuleFor(d => d.ConnString).Must(connectionString =>
             connectionString.StartsWith("Excel File="))
                .When(d => d.DataSourceTypeID==12);
            ////Excel Connection String Rules


            RuleFor(d => d.ConnString)
                .Must(connectionString =>connectionString.StartsWith("mongodb://"))
                .When(d => d.DataSourceTypeID==17);

            //MongoDb Connection String Rules

            RuleFor(d => d.ConnString).Must(connectionString =>connectionString.StartsWith("User ID=")|connectionString.StartsWith("Provider=")
            |connectionString.StartsWith("Server="))
            .Matches(".*;")
            .Must(connectionString=>connectionString.EndsWith(';'))
            .When(d => d.DataSourceTypeID==16);
            //PostgreSQL Connection String Rules


            RuleFor(d => d.ConnString).Must(connectionString =>connectionString.StartsWith("Server="))
                .Matches(".*;")
                .Matches(".*;Database=")
                .Matches(".*;UID=")
                .Matches(".*;PWD=")
                .Must(connectionString=>connectionString.EndsWith(';'))
                .When(d => d.DataSourceTypeID == 20);
            //IBMDB2 Connection String Rules


            RuleFor(d => d.ConnString).Must(connectionString => connectionString.StartsWith("Data Source="))
                .Matches(".*;Version=")
                .Matches(".*;")
                .Must(connectionString => connectionString.EndsWith(';'))
                .When(d => d.DataSourceTypeID == 18);
            //SQLlite connection string rules

            #endregion

            #region QueryStringRules

            //RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            //{
            //   if (SqlCommandValidator.TruncateSqlCommandValidatorByRegex(queryString))
            //   {
            //        context.AddFailure("You have not authenticate to using Truncate command");
            //   }
            //});

            //RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            //{
            //    if (SqlCommandValidator.CreateSqlCommandValidatorByRegex(queryString))
            //    {
            //        context.AddFailure("You have not authenticate to using Create command");
            //    }
            //});


            //RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            //{
            //   if (SqlCommandValidator.AlterSqlCommandValidatorByRegex(queryString))
            //   {
            //       context.AddFailure("You have not authenticate to using Alter command");
            //   }
            //});

            //RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            //{
            // if(SqlCommandValidator.CommentSqlCommandValidatorByRegex(queryString))
            // {
            //        context.AddFailure("You have not authenticate to using Comment command");
            // }

            //});

            //RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            //{
            //    if (SqlCommandValidator.DropSqlCommandValidatorByRegex(queryString))
            //    {
            //        context.AddFailure("You have not authenticate to using Drop command");
            //    }
            //});

            //RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            //{
            //    if (SqlCommandValidator.RollBackSqlCommandValidatorByRegex(queryString))
            //    {
            //        context.AddFailure("You have not authenticate to using Rollback command");
            //    }
            //});


            //RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            //{
            //    if (SqlCommandValidator.ModifySqlCommandValidatorByRegex(queryString))
            //    {
            //        context.AddFailure("You have not authenticate to using Modify command");
            //    }
            //});

            //RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            //{
            //    if (SqlCommandValidator.ReplaceSqlCommandValidatorByRegex(queryString))
            //    {
            //        context.AddFailure("You have not authenticate to using replace command");
            //    }

            //});

            //RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            //{
            //    if (SqlCommandValidator.DeleteSqlCommandValidatorByRegex(queryString))
            //    {
            //        context.AddFailure("You have not authenticate to using Delete command");
            //    }

            //});

            //RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            //{
            //    if (SqlCommandValidator.UpdateSqlCommandValidatorByRegex(queryString))
            //    {
            //        context.AddFailure("You have not authenticate to using Update command");
            //    }

            //});

            //RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            //{
            //    if (SqlCommandValidator.SavePointSqlCommandValidatorByRegex(queryString))
            //    {
            //        context.AddFailure("You have not authenticate to using SavePoint command");
            //    }

            //});


            //RuleFor(dataSource => dataSource.QueryString).Custom((queryString, context) =>
            //{


            //    if (SqlCommandValidator.CommitSqlCommandValidatorByRegex(queryString)
            //    ||COMMİT.IsMatch(queryString)||COMMİT.IsMatch(queryString.ToUpper())
            //    ||commıt.IsMatch(queryString)||commıt.IsMatch(queryString.ToLower()))
            //    {
            //        context.AddFailure("You have not authenticate to using Commit command and if you use COMMİT or commıt,sql can not run these commands");
            //    }

            //    //else if (COMMİT.IsMatch(queryString) || COMMİT.IsMatch(queryString.ToUpper()))
            //    //{
            //    //   context.AddFailure("Normally,SQL Query Syntax is COMMIT But Again Commit can not be usable for you !!");
            //    //

            //});

            RuleFor(dataSource => dataSource.QueryString)
                .Must(queryString => SqlCommandValidator.SelectCommandValidatorByRegex(queryString)
                || SqlCommandValidator.InsertCommandValidatorByRegex(queryString)).WithMessage("Regular Expression Hatası");


            RuleFor(dataSource => dataSource.QueryString)
                .Must(queryString => queryString == "Select" || queryString == "SELECT" || queryString == "select"
                || queryString == "Insert" || queryString == "INSERT" || queryString == "insert").WithMessage("Yazımlar böyle olmamalı");

                
                



            #endregion
        }
    }
}
