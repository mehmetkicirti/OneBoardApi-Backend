using OneBoard.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.Concrete
{
    public class DataSource : IEntity
    {
        public int ID { get; set; }
        public int DataSourceTypeID { get; set; }
        public string ConnString { get; set; }
        public string QueryString { get; set; }
        public string DataValue { get; set; }
        public int FirmID { get; set; }
        public DataSourceType DataSourceType { get; set; }
        public Firm Firm { get; set; }
        public IEnumerable<Serie> Series { get; set; }
        public IEnumerable<Widget> Widgets { get; set; }

    }
}
