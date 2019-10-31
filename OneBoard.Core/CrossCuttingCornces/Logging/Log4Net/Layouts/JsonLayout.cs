using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OneBoard.Core.CrossCuttingCornces.Logging.Log4Net.Layouts
{
    public class JsonLayout : LayoutSkeleton
    {
        public override void ActivateOptions()
        {
            //throw new NotImplementedException();
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var serializableLogEvent = new SerializableLogEvent(loggingEvent);

            var json = JsonConvert.SerializeObject(serializableLogEvent,Formatting.Indented);

            writer.WriteLine(json);
        }
    }
}
