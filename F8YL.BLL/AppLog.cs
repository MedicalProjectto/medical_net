using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.IO;

namespace F8YL.BLL
{
    public class AppLog
    {
        #region Private Function

        private static ILog _mLog;

        /// <summary>
        /// Write Log By MessageType
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="messageType">MessageType</param>
        /// <param name="ex">Exception Object</param>
        /// <param name="type">Log Source Type</param>
        private static void DoLog(string message, LogMessageType messageType, Exception ex, Type type)
        {
            string stackTrace = string.Empty;
            if (ex != null)
            {
                stackTrace = ex.StackTrace;
            }
            _mLog = LogManager.GetLogger(type);
            switch (messageType)
            {
                case LogMessageType.Debug:
                    //AppLog._mLog.Debug(message + " ExceptionStackTrace:" + stackTrace, ex);//Edit by Gerry
                    AppLog._mLog.Debug(message + stackTrace, ex);
                    break;
                case LogMessageType.Info:
                    AppLog._mLog.Info(message + stackTrace, ex);
                    break;
                case LogMessageType.Warn:
                    AppLog._mLog.Warn(message + stackTrace, ex);
                    break;
                case LogMessageType.Error:
                    AppLog._mLog.Error(message + stackTrace, ex);
                    break;
                case LogMessageType.Fatal:
                    AppLog._mLog.Fatal(message + stackTrace, ex);
                    break;
            }
        }

        #endregion

        #region Public Function
        /// <summary>
        /// Init Log
        /// </summary>
        public AppLog()
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Web.config")));
        }

        public static readonly AppLog Instance = new AppLog();

        /// <summary>
        /// Write Log By MessageType
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="messageType">MessageType</param>
        public void Write(string message, LogMessageType messageType)
        {
            DoLog(message, messageType, null, Type.GetType("System.Object"));
        }

        /// <summary>
        /// Write Log By MessageType And Log Source Type
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="messageType">MessageType</param>
        /// <param name="type">Log Source Type</param>
        public void Write(string message, LogMessageType messageType, Type type)
        {
            DoLog(message, messageType, null, type);
        }

        /// <summary>
        /// Write Log By MessageType And Exception Object
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="messageType">MessageType</param>
        /// <param name="ex">Exception Object</param>
        public void Write(string message, LogMessageType messageType, Exception ex)
        {
            DoLog(message, messageType, ex, Type.GetType("System.Object"));
        }

        /// <summary>
        /// Write Log By MessageType, Exception Object And Log Source Type
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="messageType">MessageType</param>
        /// <param name="ex">Exception Object</param>
        /// <param name="type">Log Source Type</param>
        public void Write(string message, LogMessageType messageType, Exception ex, Type type)
        {
            DoLog(message, messageType, ex, type);
        }


        /// <summary>
        /// Log Message Type Enum
        /// </summary>
        public enum LogMessageType
        {
            /// <summary>
            /// Debug
            /// </summary>
            Debug,

            /// <summary>
            /// Info
            /// </summary>
            Info,

            /// <summary>
            /// Warn
            /// </summary>
            Warn,

            /// <summary>
            /// Error
            /// </summary>
            Error,

            /// <summary>
            /// Fatal
            /// </summary>
            Fatal
        }
        #endregion
    }
}
