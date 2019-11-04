using OneBoard.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.DTO.Dashboard
{
    public class DashboardDTO:IDTO
    {
        public int FirmID { get; set; }
        public int CreatorID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
