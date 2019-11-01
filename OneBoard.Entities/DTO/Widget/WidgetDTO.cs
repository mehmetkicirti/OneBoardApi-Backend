using OneBoard.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.DTO.Widget
{
    public class WidgetDTO:IDTO
    {
        public int? DashboardID{ get; set; }
        public int WidgetTypeID { get; set; }
        public int PositionX{ get; set; }
        public int PositionY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Title { get; set; }
        public int? GoalValue { get; set; }
        public int DataSourceID { get; set; }
    }
}
