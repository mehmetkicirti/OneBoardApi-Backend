using OneBoard.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.DTO.User
{
    public class UserDTO:IDTO
    {
        public string UserName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
    }
}
