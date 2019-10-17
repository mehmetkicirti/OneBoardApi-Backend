using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Core.Utilities.Results.Concerete.Result
{
    public class SuccessResult : GeneralResult
    {
        public SuccessResult():base(true)
        {
        }

        public SuccessResult(string message) : base(message,true)
        {
        }
    }
}
