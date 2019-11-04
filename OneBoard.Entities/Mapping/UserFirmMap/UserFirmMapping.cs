using AutoMapper;
using OneBoard.Entities.Concrete;
using OneBoard.Entities.DTO.UserFirm;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.Mapping.UserFirmMap
{
    public class UserFirmMapping:Profile
    {
        public static MapperConfiguration GetMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserFirmDTO, UserFirm>()
                .ForMember(userfirmElement => userfirmElement.Firm, option => option.Ignore())
                .ForMember(userfirmElement => userfirmElement.User, option => option.Ignore());

                cfg.CreateMap<UserFirm, UserFirmDTO>();
            });

            return config;
        }
       

        
        
        
        
     }
}
