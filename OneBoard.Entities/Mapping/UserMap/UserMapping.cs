using AutoMapper;
using OneBoard.Entities.Concrete;
using OneBoard.Entities.DTO.User;

namespace OneBoard.Entities.Mapping.UserMap
{
   public class UserMapping:Profile
    {
        public static MapperConfiguration GetMapper()
        {
            MapperConfiguration config = null;
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>().ForMember(u => u.UserFirms, option => option.Ignore())
        .ForMember(u => u.UserGroups, option => option.Ignore());
                cfg.CreateMap<User, UserDTO>();
            });
            return config;
        }
    }
}
