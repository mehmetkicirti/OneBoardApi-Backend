using OneBoard.Entities.Abstract;
using OneBoard.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.Concrete
{
    public class WidgetType:IEntity
    {
        public int ID { get; set; }
        public string WidgetTypeName { get; set; }

        //public WidgetTypeEnum WidgetTypeName { get; set; }
        public IEnumerable<Widget> Widgets { get; set; }
    }
}
