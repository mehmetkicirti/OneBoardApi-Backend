using System;
using System.Collections.Generic;
using System.Text;
using OneBoard.Core.Entity;

namespace OneBoard.Entities.Concrete
{
   public class UserFirm:IEntity
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int FirmID { get; set; }
        public User User { get; set; }
        public Firm Firm { get; set; }
    }
}
