using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Core.Utilities.Results.Concerete.Data
{
    public class FailDataResult<T>:DataResult<T>
    {
        public FailDataResult(T data, bool Success, string Message) : base(data, false, Message)
        {



        }

        public FailDataResult(T data, bool Success) : base(data, false)
        {

        }

       
    }
}
