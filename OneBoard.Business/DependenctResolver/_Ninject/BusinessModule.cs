using Microsoft.EntityFrameworkCore;
using Ninject.Modules;
using OneBoard.DataAccess.Abstract;
using OneBoard.DataAccess.EF;
using OneBoard.DataAccess.EF.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Business.DependenctResolver._Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserDal>().To<EfUserDal>();
            Bind<IUserFirmDal>().To<EfUserFirmDal>();
            Bind<IUserGroupDal>().To<EfUserGroupDal>();
            Bind<IGroupDal>().To<EfGroupDal>();
            Bind<IFirmDal>().To<EfFirmDal>();
            Bind<IDashboardDal>().To<EfDashboardDal>();
            Bind<IWidgetDal>().To<EfWidgetDal>();
            Bind<IWidgetTypeDal>().To<EfWidgetTypeDal>();
            Bind<IDataSourceDal>().To<EfDataSourceDal>();
            Bind<IDataSourceTypeDal>().To<EfDataSourceTypeDal>();
            Bind<IChartTypeDal>().To<EfChartTypeDal>();
            Bind<ISerieDal>().To<EfSerieDal>();

            //Bind<DbContext>().To<DatabaseContext>();

        }
    }
}
