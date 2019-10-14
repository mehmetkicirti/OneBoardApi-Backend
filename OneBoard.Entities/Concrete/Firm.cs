using OneBoard.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.Concrete
{
    public class Firm:IEntity
    {
        public int ID { get; set; }
        public int? ParentID { get; set; }
        public string FirmName { get; set; }

        public IEnumerable<UserFirm> UserFirms { get; set; }
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<Dashboard> Dashboards { get; set; }
    }
}
