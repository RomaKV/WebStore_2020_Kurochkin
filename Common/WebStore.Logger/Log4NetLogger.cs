using log4net;
using log4net.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Xml;
using log4net.Util;

namespace WebStore.Logger
{
    public class Log4NetLogger : ILogger
    {

        private readonly string name;
        private readonly XmlElement xmlElement;
        private readonly ILog log;
        private readonly ILoggerRepository loggerRepository;

        public Log4NetLogger(string name, XmlElement xmlElement)
        {
            this.name = name;
            this.xmlElement = xmlElement;
            this.loggerRepository = LogManager.CreateRepository(
                 Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

               log4net.Config.XmlConfigurator.Configure(this.loggerRepository, xmlElement);

        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }


        
        
        public string Name => throw new NotImplementedException();

        public ILoggerRepository Repository => throw new NotImplementedException();

       

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentException(nameof(formatter));
            }

            var message = formatter(state, exception);
            
            if (string.IsNullOrEmpty(message) && exception == null)
            {
                return;
            }

            if (logLevel == LogLevel.Critical)
            {
               this.log.Fatal(message);
            }
            else if (logLevel == LogLevel.Debug ||
                     logLevel == LogLevel.Trace)
            {
                this.log.Debug(message);
            }
            else if (logLevel == LogLevel.Error)
            {
                this.log.Error(message);
            }
            else if (logLevel == LogLevel.Warning)
            {
                this.log.Info(message);
            }
            else if (logLevel == LogLevel.None)
            {
                return;
            }
            else
            {
                this.log.Warn($"Encountered unknown log level {logLevel}, writing out as Info");
                
                this.log.Info(message, exception);
            }

        }

        
        public bool IsEnabled(LogLevel logLevel)
        {
           if (logLevel ==LogLevel.Critical)
           {
                return this.log.IsFatalEnabled;  
           }
           else if (logLevel == LogLevel.Debug ||
                logLevel == LogLevel.Trace)
           {
                return this.log.IsDebugEnabled;
           }
           else if (logLevel == LogLevel.Error)
           {
                return this.log.IsErrorEnabled;
           }
           else if (logLevel == LogLevel.Warning)
           {
               return this.log.IsWarnEnabled;
           }
           else if (logLevel == LogLevel.None)
           {
               return false;
           }
           else
           {
               throw new ArgumentOutOfRangeException(nameof(logLevel));
           }
        }
    }
}
