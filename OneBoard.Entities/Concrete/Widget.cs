using OneBoard.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.Concrete
{
    public class Widget:IEntity
    {
        public int ID { get; set; }
        public int? DashboardID { get; set; }
        public int WidgetTypeID { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Title { get; set; }
        public int? GoalValue { get; set; }
        public int DataSourceID { get; set; }

        public WidgetType WidgetType { get; set; }
        public Dashboard Dashboard{ get; set; }
        public DataSource DataSource{ get; set; }

        public IEnumerable<Serie> Series{ get; set; }
    }
}
