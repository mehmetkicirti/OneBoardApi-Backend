using AutoMapper;
using OneBoard.Entities.Concrete;
using OneBoard.Entities.DTO.UserGroup;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.Mapping.UserGroupMap
{
    public class UserGroupMapping:Profile
    {
        public static MapperConfiguration GetMapper()
        {
            MapperConfiguration config;

            config = new MapperConfiguration(
                cfg => {
                    cfg.CreateMap<UserGroup, UserGroupDTO>();
                    cfg.CreateMap<UserGroupDTO, UserGroup>()
                        .ForMember(ug=>ug.User, option=>option.Ignore())
                        .ForMember(ug=>ug.Group, option=>option.Ignore());
                }) ;
                
            return config;
        }
    }
}
