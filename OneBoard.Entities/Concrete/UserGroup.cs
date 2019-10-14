using System;
using System.Collections.Generic;
using System.Text;
using OneBoard.Core.Entity;

namespace OneBoard.Entities.Concrete
{
    public class UserGroup:IEntity
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int GroupID { get; set; }

        public User User{ get; set; }
        public Group Group{ get; set; }
    }
}
