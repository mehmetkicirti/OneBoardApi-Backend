﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Core.Utilities.Results.Abstract
{
    public interface IResult
    {
        bool Success { get; set; }
        string Message { get; set; }
    }
}
