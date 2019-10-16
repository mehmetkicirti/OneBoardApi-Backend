using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Core.Utilities.Results.Concerete.Result
{
    public class FailResult:GeneralResult
    {
        public FailResult(bool Success) : base(Success:false)
        {

        }

        public FailResult(string message) : base(message, false)
        {

        }
       
    }
}
