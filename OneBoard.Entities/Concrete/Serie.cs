using OneBoard.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.Concrete
{
   public class Serie:IEntity
    {
        public int ID { get; set; }
        public int ChartTypeID { get; set; }
        public int? WidgetID { get; set; }
        public int DataSourceID { get; set; }

        public ChartType ChartType { get; set; }
        public Widget Widget { get; set; }
        public DataSource DataSource { get; set; }
    }
}
