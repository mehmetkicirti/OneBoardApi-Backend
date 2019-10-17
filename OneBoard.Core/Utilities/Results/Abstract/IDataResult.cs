using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Core.Utilities.Results.Abstract
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get;}
    }
}
