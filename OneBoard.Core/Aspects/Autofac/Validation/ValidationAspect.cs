using Castle.DynamicProxy;
using FluentValidation;
using OneBoard.Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OneBoard.Core.CrossCuttingCornces.Validation._FluentValidation;
using OneBoard.Core.Utilities.Constants;

namespace OneBoard.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect:MethodInterceptors
    {
        private Type validationType;

        public ValidationAspect(Type type)
        {
            if (!typeof(IValidator).IsAssignableFrom(type))
            {
                throw new Exception(AspectMessage.Validation_Type_Exception_Messages);
            }

            this.validationType = type;
        }

        public override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(validationType);
            var entityType = validationType.BaseType.GetGenericArguments()[0];


            var entities = invocation.Arguments.Where(e => e.GetType() == entityType);

            foreach(var entity in entities)
            {
                FluentValidationTool.Validate(validator, entity);
            }

           
        }


       
    }
}
