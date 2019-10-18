using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using OneBoard.DataAccess.Abstract;
using OneBoard.DataAccess.EF;
using OneBoard.DataAccess.EF._DatabaseContext;
using OneBoard.Business.Concrete;
using OneBoard.Business.Abstract;

namespace OneBoard.Business.DependenctResolver._Autofac
{
   public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<EfGroupDal>().As<IGroupDal>();
            builder.RegisterType<EfFirmDal>().As<IFirmDal>();
            builder.RegisterType<EfDashboardDal>().As<IDashboardDal>();
            builder.RegisterType<EfSerieDal>().As<ISerieDal>();
            builder.RegisterType<EfDataSourceDal>().As<IDataSourceDal>();
            builder.RegisterType<EfChartTypeDal>().As<IChartTypeDal>();
            builder.RegisterType<EfDataSourceTypeDal>().As<IDataSourceTypeDal>();
            builder.RegisterType<EfWidgetDal>().As<IWidgetDal>();
            builder.RegisterType<EfWidgetTypeDal>().As<IWidgetTypeDal>();
            builder.RegisterType<EfUserGroupDal>().As<DataAccess.Abstract.IUserGroupDal>();
            builder.RegisterType<EfUserFirmDal>().As<DataAccess.Abstract.IUserFirmDal>();


            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<GroupManager>().As<IGroupService>();
            builder.RegisterType<FirmManager>().As<IFirmService>();
            builder.RegisterType<DashboardManager>().As<IDashboardService>();
            builder.RegisterType<SerieManager>().As<ISerieService>();
            builder.RegisterType<DataSourceManager>().As<IDataSourceService>();
            builder.RegisterType<ChartTypeManager>().As<IChartTypeService>();
            builder.RegisterType<WidgetManager>().As<IWidgetService>();
            builder.RegisterType<WidgetTypeManager>().As<IWidgetTypeService>();
            builder.RegisterType<UserFirmManager>().As<IUserFirmService>();
            builder.RegisterType<UserGroupManager>().As<IUserGroupService>();
            builder.RegisterType<DataSourceTypeManager>().As<IDataSourceService>();

        }
    }
}
