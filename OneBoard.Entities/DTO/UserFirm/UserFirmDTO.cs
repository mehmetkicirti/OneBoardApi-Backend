using OneBoard.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.DTO.UserFirm
{
   public class UserFirmDTO:IDTO
    {
        public int UserID { get; set; }
        public int FirmID { get; set; }
    }
}
