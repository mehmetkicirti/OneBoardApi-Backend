using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple =true,Inherited =true)]
    public abstract class MethodInterceptorsAttributeBase : Attribute, IInterceptor
    {
        private int priority;
        public int Priority { get { return priority; } set { value = priority; } }

        public virtual void Intercept(IInvocation invocation)
        {
            
        }
    }
}
