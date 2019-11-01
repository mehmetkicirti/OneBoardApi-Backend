using AutoMapper;
using OneBoard.Entities.Concrete;
using OneBoard.Entities.DTO.WidgetType;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.Mapping.WidgetTypeMap
{
    public class WidgetTypeMapping:Profile
    {

        static MapperConfiguration GetMapper()
        {
            MapperConfiguration config;

            config = new MapperConfiguration(
                cfg => {
                    cfg.CreateMap<WidgetType, WidgetTypeDTO>();
                    cfg.CreateMap<WidgetTypeDTO, WidgetType>().ForMember(w=>w.Widgets, opt=>opt.Ignore());
                    });

            return config;
        }
    }
}
