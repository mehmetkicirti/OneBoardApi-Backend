using OneBoard.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.Concrete
{
   public class ChartType:IEntity
    {
        public int ID { get; set; }
        public string ChartTypeName { get; set; }
        public IEnumerable<Serie> Series{ get; set; }
    }
}
