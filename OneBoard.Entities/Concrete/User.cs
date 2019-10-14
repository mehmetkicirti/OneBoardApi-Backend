using OneBoard.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OneBoard.Entities.Concrete
{
    public class User:IEntity
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string LoginName { get; set; }
        public DateTime LastLogin { get; set; }
        public int UserType{ get; set; }
        public string Token{ get; set; }
        public IEnumerable<UserFirm> UserFirms { get; set; }
        public IEnumerable<UserGroup> UserGroups { get; set; }
        public IEnumerable<Dashboard> Dashboards { get; set; }
    }
}
