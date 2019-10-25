using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Core.Utilities.Interceptors
{
   public abstract class MethodInterceptors:MethodInterceptorsAttributeBase
    {

        public virtual void OnBefore(IInvocation invocation)
        { 
        }

        public virtual void OnAfter(IInvocation invocation) { }

        public virtual void OnSuccess(IInvocation invocation) { }

        public virtual void OnException(IInvocation invocation) { }

        public override void Intercept(IInvocation invocation)
        {
            bool IsSuccess = true;
            OnBefore(invocation);

            try
            {
                invocation.Proceed();
            }

            catch(Exception e)
            {
                IsSuccess = false;
                OnException(invocation);
                throw;
            }

            finally
            {
                if (IsSuccess == true)
                {
                    OnSuccess(invocation);
                }
            }

            OnAfter(invocation);
        }

    }
}
