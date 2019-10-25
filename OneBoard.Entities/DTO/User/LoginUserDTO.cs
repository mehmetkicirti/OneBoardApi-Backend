using OneBoard.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OneBoard.Entities.DTO.User
{
    public class LoginUserDTO:IDTO
    {
        [Required(ErrorMessage ="Login Name is not null.")]
        public string LoginName{ get; set; }
        [Required(ErrorMessage ="Password is not null.")]
        public string Password { get; set; }
    }
}
