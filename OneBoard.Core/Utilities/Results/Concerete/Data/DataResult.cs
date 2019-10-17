using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Core.Utilities.Results.Concerete.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Core.Utilities.Results.Concerete.Data
{
    public class DataResult<T> : GeneralResult, IDataResult<T>
    {

        public T Data { get;}
        public DataResult(T data, bool Success) : base(Success)
        {
            Data = data;
        }


        public DataResult(T data, bool Success, string Message) : base(Message, Success)
        {
            this.Data = data;
        }

    }
       
    }

