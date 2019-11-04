using OneBoard.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.DTO.Group
{
    public class GroupDTO:IDTO
    {
        public string GroupName { get; set; }
        public int FirmID { get; set; }
    }
}
