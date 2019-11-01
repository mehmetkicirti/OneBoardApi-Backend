using OneBoard.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OneBoard.Entities.DTO.User
{
    public class LoginUserDTO:IDTO
    {
        public string LoginName{ get; set; }
        public string Password { get; set; }
    }
}
