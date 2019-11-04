using AutoMapper;
using OneBoard.Entities.Concrete;
using OneBoard.Entities.DTO.Serie;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.Mapping.SerieMap
{
    public class SerieMapping:Profile
    {
        public static MapperConfiguration GetMapper()
        {
            MapperConfiguration config = null;
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SerieDTO, Serie>()
                .ForMember(serieElement => serieElement.ChartType, option => option.Ignore())
                .ForMember(serieElement => serieElement.DataSource, option => option.Ignore())
                .ForMember(serieElement => serieElement.Widget, option => option.Ignore());
                
                
                cfg.CreateMap<Serie,SerieDTO>();


            });

            return config;
        }
    }
}
