using NLog.Config;

namespace DARtoOAR
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // create a configuration instance
            LoggingConfiguration config = new LoggingConfiguration();

            // create a console logging target
            var logTarget = new NLog.Targets.FileTarget() { FileName = "${basedir}\\DARtoOAR.log", ArchiveOldFileOnStartup = true, DeleteOldFileOnStartup = true };

            // send logs with levels from Info to Fatal to the console
            config.AddRule(NLog.LogLevel.Debug, NLog.LogLevel.Fatal, logTarget);

            // apply the configuration
            NLog.LogManager.Configuration = config;

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new UI());
        }
    }
}