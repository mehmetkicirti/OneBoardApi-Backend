using AutoMapper;
using OneBoard.Entities.Concrete;
using OneBoard.Entities.DTO.Group;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.Mapping.GroupMap
{
    public class GroupMapping:Profile
    {
        public static MapperConfiguration GetMapper()
        {
            MapperConfiguration config = null;
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GroupDTO, Group>()
                .ForMember(g => g.Firm, option => option.Ignore())
                .ForMember(g => g.UserGroups, option => option.Ignore());
                cfg.CreateMap<Group,GroupDTO>();
            });
            return config;
        }
    }
}
