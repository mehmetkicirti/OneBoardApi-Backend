using OneBoard.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Core.Utilities.Results.Concerete.Result
{
    public class GeneralResult : IResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

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
