using OneBoard.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.Concrete
{
    public class Group:IEntity
    {
        public int ID { get; set; }
        public string GroupName{ get; set; }
        public int FirmID{ get; set; }
        public Firm Firm{ get; set; }
        public IEnumerable<UserGroup> UserGroups { get; set; }
    }
}
