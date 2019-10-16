﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Core.Utilities.Results.Abstract
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; set; }
    }
}
