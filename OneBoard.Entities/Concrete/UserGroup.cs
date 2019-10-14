using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.Concrete
{
    public class UserGroup
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int GroupID { get; set; }

        public User User{ get; set; }
        public Group Group{ get; set; }
    }
}
