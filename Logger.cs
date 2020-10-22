using log4net;
using log4net.Repository.Hierarchy;
using log4net.Core;
using log4net.Appender;
using log4net.Layout;
using System;

namespace RestAPITest
{
    public static class RestLogger
    {
        private static log4net.ILog Log { get; set; }

        static RestLogger()
        { 
            LoggerSetup();
            Log = log4net.LogManager.GetLogger(typeof(RestLogger));
        }

        public static void Error(string msg,params object[] parameters)
        {
            Log.Error(string.Format(msg,parameters));
        }

        public static void Info(string msg,params object[] parameters)
        {
            Log.Info(string.Format(msg,parameters));
        }
        public static void LoggerSetup()
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = ConstUtil.LogConversionPattern;
            patternLayout.ActivateOptions();

            RollingFileAppender roller = new RollingFileAppender();
            roller.AppendToFile = false;
            roller.File = ConstUtil.LogPath;
            roller.Layout = patternLayout;
            roller.MaxSizeRollBackups = ConstUtil.MaxSizeRollBackup;
            roller.MaximumFileSize = ConstUtil.MaxLogSize;
            roller.RollingStyle = RollingFileAppender.RollingMode.Size;
            roller.StaticLogFileName = true;            
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);

            MemoryAppender memory = new MemoryAppender();
            memory.ActivateOptions();
            hierarchy.Root.AddAppender(memory);

            hierarchy.Root.Level = Level.Info;
            hierarchy.Configured = true;
        }
    }
}