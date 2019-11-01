using AutoMapper;
using OneBoard.Entities.Concrete;
using OneBoard.Entities.DTO.Widget;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.Mapping.WidgetMap
{
    public class WidgetMapping : Profile
    {
        static MapperConfiguration GetMapper()
        {
            MapperConfiguration config;

            config = new MapperConfiguration(
                  cfg =>
                  {
                      cfg.CreateMap<Widget, WidgetDTO>();
                      cfg.CreateMap<WidgetDTO, Widget>()
                      .ForMember(w => w.WidgetType, option => option.Ignore())
                      .ForMember(w => w.Dashboard, option => option.Ignore())
                      .ForMember(w => w.DataSource, option => option.Ignore())
                      .ForMember(w => w.Series, option => option.Ignore());
                  });

            return config;
        }

    }
}
