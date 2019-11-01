using AutoMapper;
using OneBoard.Entities.Concrete;
using OneBoard.Entities.DTO.DataSource;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.Mapping.DataSourceMap
{
   public class DataSourceMapping:Profile
    {

        public static MapperConfiguration GetMapper()
        {
            MapperConfiguration config = null;
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DataSourceDTO, DataSource>().ForMember(d => d.DataSourceType, option => option.Ignore())
                    .ForMember(d => d.Firm, option => option.Ignore()).ForMember(d => d.Series, option => option.Ignore())
                    .ForMember(d => d.Widgets, option => option.Ignore());
                cfg.CreateMap<DataSource, DataSourceDTO>();
            });
            return config;
        }
        
    }
}
