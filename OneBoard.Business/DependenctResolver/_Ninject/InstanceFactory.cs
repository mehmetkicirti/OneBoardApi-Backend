using Ninject;
using OneBoard.Business.DependenctResolver._Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.DependenctResolver._Ninject
{
    public class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new BusinessModule());
            return kernel.Get<T>();
        }
    }
}
