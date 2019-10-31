using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Core.CrossCuttingCornces.Logging
{
   public class LogDetail
    {
        public string MethodName { get; set; }

        public List<LogParameter> Parameters { get; set; }
    }
}
