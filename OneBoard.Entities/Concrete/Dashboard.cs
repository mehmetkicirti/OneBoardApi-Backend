using OneBoard.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OneBoard.Entities.Concrete
{
    public class Dashboard:IEntity
    {
        public int ID { get; set; }
        public int FirmID { get; set; }
        public int CreatorID { get; set; }
        public DateTime CreatedDate{ get; set; }
        public DateTime? ModifiedDate { get; set; }

        [ForeignKey("CreatorID")]
        public User User { get; set; }
        public Firm Firm{ get; set; }
    }
}
