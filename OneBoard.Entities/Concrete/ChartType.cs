using OneBoard.Entities.Abstract;
using OneBoard.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.Concrete
{
   public class ChartType:IEntity
    {
        public int ID { get; set; }
        public string ChartTypeName { get; set; }

       // public ChartTypeEnum CharTypeName { get; set; }
        public IEnumerable<Serie> Series{ get; set; }
    }
}
