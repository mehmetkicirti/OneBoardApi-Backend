using OneBoard.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.DTO.Serie
{
    public class SerieDTO:IDTO
    {
        public int ChartTypeID { get; set; }
        public int? WidgetID { get; set; }
        public int DataSourceID { get; set; }
    }
}
