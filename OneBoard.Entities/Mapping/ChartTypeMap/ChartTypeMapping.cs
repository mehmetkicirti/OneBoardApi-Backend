using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using OneBoard.Entities.Concrete;
using OneBoard.Entities.DTO.ChartType;

namespace OneBoard.Entities.Mapping.ChartTypeMap
{
    public class ChartTypeMapping : Profile
    {

        public static MapperConfiguration GetMapper()
        {
            MapperConfiguration config = null;
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ChartTypeDTO, ChartType>()
                .ForMember(chartTypeElement => chartTypeElement.Series, option => option.Ignore());

                cfg.CreateMap<ChartType, ChartTypeDTO>();

            });

            return config;
        }
    }
}
