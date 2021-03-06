﻿using AutoMapper;
using OneBoard.Entities.Concrete;
using OneBoard.Entities.DTO.Firm;

namespace OneBoard.Entities.Mapping.FirmMap
{
    public class FirmMapping:Profile
    {
        //public FirmMapping()
        //{
        //    CreateMap<Firm, FirmDTO>();
        //    CreateMap<FirmDTO, Firm>().ForMember(f => f.Dashboards, option => option.Ignore())
        //    .ForMember(f => f.UserFirms, option => option.Ignore()).ForMember(f => f.Groups, option => option.Ignore());
        //}
        
        public static MapperConfiguration GetMapper()
        {
            MapperConfiguration config = null;
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FirmDTO, Firm>().ForMember(f => f.Dashboards, option => option.Ignore())
        .ForMember(f => f.UserFirms, option => option.Ignore()).ForMember(f => f.Groups, option => option.Ignore()); ;
                cfg.CreateMap<Firm, FirmDTO>();
            });
            return config;
        }
    }
}
