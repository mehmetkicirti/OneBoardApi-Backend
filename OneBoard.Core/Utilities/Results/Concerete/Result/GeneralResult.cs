using OneBoard.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Core.Utilities.Results.Concerete.Result
{
    public class GeneralResult : IResult
    {
        public bool Success { get;}
        public string Message { get;}

        public GeneralResult(string Message,bool Success) : this(Success)
        {
            this.Message = Message;
        }
        public GeneralResult(bool Success)
        {
            this.Success = Success;
        }
    }
}
