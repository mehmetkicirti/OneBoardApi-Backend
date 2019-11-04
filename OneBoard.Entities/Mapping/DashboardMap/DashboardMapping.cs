using AutoMapper;
using OneBoard.Entities.Concrete;
using OneBoard.Entities.DTO.Dashboard;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.Mapping.DashboardMap
{
    public class DashboardMapping : Profile
    {
        public static MapperConfiguration GetMapper()
        {
            MapperConfiguration config = null;
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DashboardDTO, Dashboard>()
                .ForMember(dashboardElement => dashboardElement.Firm, option => option.Ignore())
                .ForMember(dashboardElement => dashboardElement.User, option => option.Ignore());

                cfg.CreateMap<Dashboard, DashboardDTO>();


            });

            return config;
        }
    }
}
