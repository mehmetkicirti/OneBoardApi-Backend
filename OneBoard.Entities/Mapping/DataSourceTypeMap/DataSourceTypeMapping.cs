using AutoMapper;
using OneBoard.Entities.Concrete;
using OneBoard.Entities.DTO.DataSourceType;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.Mapping.DataSourceTypeMap
{
    public class DataSourceTypeMapping:Profile
    {
        public static MapperConfiguration GetMapper()
        {
            MapperConfiguration config;

            config = new MapperConfiguration(
                cfg => {
                    cfg.CreateMap<DataSourceType, DataSourceTypeDTO>();
                    cfg.CreateMap<DataSourceTypeDTO, DataSourceType>();
                });

            return config;
        }
    }
}
