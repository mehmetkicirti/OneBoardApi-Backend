﻿using FluentValidation;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;


namespace OneBoard.Business.ValidationRules._FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.UserName)
                .NotNull()
                .NotEqual(username => username.LoginName)
                .MinimumLength(3)
                .WithMessage("Error");

        }
    }
}
