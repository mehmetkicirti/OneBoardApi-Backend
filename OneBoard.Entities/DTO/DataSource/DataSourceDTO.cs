using OneBoard.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.DTO.DataSource
{
   public class DataSourceDTO:IDTO
    {
        public int DataSourceTypeID { get; set; }
        public string ConnString { get; set; }
        public string QueryString { get; set; }
        public string DataValue { get; set; }
        public int FirmID { get; set; }
    }
}
