﻿using OneBoard.Entities.Abstract;
using OneBoard.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Entities.Concrete
{
    public class DataSourceType:IEntity
    {
        public int ID { get; set; }

        public string DataSourceTypeName { get; set; }

       // public DataSourceTypeEnum DataSourceTypeName { get; set; }

        public IEnumerable<DataSource> DataSources{ get; set; }
    }
}
