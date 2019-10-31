using log4net.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Core.CrossCuttingCornces.Logging.Log4Net
{

    [Serializable]
    public class SerializableLogEvent
    {
        private LoggingEvent loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingevent)
        {
            this.loggingEvent = loggingevent;
        }

        public object Message => loggingEvent.MessageObject;
    }
}
