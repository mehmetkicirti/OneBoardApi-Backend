using log4net;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace OneBoard.Core.CrossCuttingCornces.Logging.Log4Net
{
    public class LoggerBaseService
    {
        private ILog log;

        public LoggerBaseService(string name)
        {
            XmlDocument document = new XmlDocument();
            document.Load(File.OpenRead(path: "log4net.config"));

            ILoggerRepository loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                 typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(loggerRepository,document["log4net"]);

            log = LogManager.GetLogger(loggerRepository.Name, name);
        }


        private bool IsDebugEnabled => log.IsDebugEnabled;
        private bool IsInfoEnabled => log.IsInfoEnabled;
        private bool IsErrorEnabled => log.IsErrorEnabled;
        private bool IsFatalEnabled => log.IsFatalEnabled;
        private bool IsWarnEnabled => log.IsWarnEnabled;


        public void Info(object logMessage)
        {
            if (IsInfoEnabled)
            {
                log.Info(logMessage);
            }
        }

        public void Debug(object logMessage)
        {
            if (IsDebugEnabled)
            {
                log.Debug(logMessage);
            }
        }

        public void Error(object logMessage)
        {
            if (IsErrorEnabled)
            {
                log.Error(logMessage);
            }
        }

        public void Fatal(object logMessage)
        {
            if (IsFatalEnabled)
            {
                log.Fatal(logMessage);
            }
        }

        public void Warn(object logMessage)
        {
            if (IsWarnEnabled)
            {
                log.Warn(logMessage);
            }
        }
    }
}
