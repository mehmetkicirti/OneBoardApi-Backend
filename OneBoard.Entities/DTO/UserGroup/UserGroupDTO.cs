using OneBoard.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.DTO.UserGroup
{
    public class UserGroupDTO:IDTO
    {
        public int UserID { get; set; }
        public int GroupID { get; set; }
    }
}
