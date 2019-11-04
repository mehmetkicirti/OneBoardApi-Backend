using Castle.DynamicProxy;
using OneBoard.Core.CrossCuttingCornces.Logging;
using OneBoard.Core.CrossCuttingCornces.Logging.Log4Net;
using OneBoard.Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneBoard.Core.Aspects.Autofac.Logging
{
   public class LogAspect:MethodInterceptors
    {
        public LoggerBaseService service { get; set; }

        public LogAspect(Type loggerServiceType)
        {
            service = (LoggerBaseService)Activator.CreateInstance(loggerServiceType);
        }


       


        public override void OnException(IInvocation invocation)
        {
            service.Error(GetLogDetail(invocation));
            base.OnException(invocation);
        }

      


        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = invocation.Arguments.Select(a => new LogParameter
            {
                Value = a,
                Name = a.ToString(),
                Type = a.GetType().ToString()

            }).ToList();

            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                Parameters = logParameters
            };

            return logDetail;
        }
    }
}
