# Web Logging

Web logging using *log4net*

1. Add *log4net* lib from nuget to your application


2. Configure log4net in *web.config* file

```xml
<configuration>
  <configSections>
    <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />
  </configSections>
  <log4net>
    <root>
      <level value="ALL" />
      <appender-ref ref="LogFileAppender" />
    </root>
    <appender name="LogFileAppender" type="log4net.Appender.RollingFileAppender">
      <param name="File" value="D:\logFileFaculty.log" />
      <param name="AppendToFile" value="true" />
      <rollingStyle value="Size" />
      <maxSizeRollBackups value="10" />
      <maximumFileSize value="10MB" />
      <staticLogFileName value="true" />
      <layout type="log4net.Layout.PatternLayout">
        <param name="ConversionPattern" value="%date [%thread] %-5level %logger [%property{NDC}] - %message%newline" />
      </layout>
    </appender>
  </log4net>
    
    ...

  ```

3. Add below code snippet in **.cs* file

```cs
 public class HomeController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            try
            {
                Log.Debug("Log Debug Level");
                Log.Info("Log Info Level");
                Log.Warn("Log Warn Level");
                throw new NullReferenceException();
                //return View();
            }
            catch (Exception ex)
            {
                Log.Error("Log Error Level", ex);
                Log.Fatal("Log Fatal Level", ex);
                throw;
            }
        }
    }
```

4. Configure xml configuration in *AssemblyInfo.cs* file

```cs
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
```
