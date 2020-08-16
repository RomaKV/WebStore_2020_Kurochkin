using System.Collections.Concurrent;
using System.IO;
using System.Xml;
using Microsoft.Extensions.Logging;

namespace WebStore.Logger
{
    public class Log4NetProvider: ILoggerProvider
  {

      private readonly string log4NetConfigFile;
      private readonly  ConcurrentDictionary<string, Log4NetLogger> loggers=
          new ConcurrentDictionary<string, Log4NetLogger>();

      public Log4NetProvider(string log4NetConfigFile)
      {
          this.log4NetConfigFile = log4NetConfigFile;
      }

      public void Dispose()
      {
            this.loggers.Clear();
      }

      public ILogger CreateLogger(string categoryName)
      {
          return this.loggers.GetOrAdd(categoryName, CreateLoggerImplementation);
      }

      private Log4NetLogger CreateLoggerImplementation(string name)
      {
          return  new Log4NetLogger(name, ParseLog4NetConfigFile(this.log4NetConfigFile));
      }

      private static XmlElement ParseLog4NetConfigFile(string filename)
      {
            var log4NetConfig = new XmlDocument();
            log4NetConfig.Load(File.OpenRead(filename));
            return log4NetConfig["log4net"];
      }


    }
}
