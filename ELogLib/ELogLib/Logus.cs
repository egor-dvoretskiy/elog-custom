using ELogLib.Enums;
using ELogLib.Interfaces;
using ELogLib.LogHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ELogLib
{
    public class Logus : ILog
    {
        private ILog logger;

        public Logus(LoggerType type = LoggerType.Custom)
        {
            this.Type = LoggerType.Custom;
            this.AssignLogger();
        }

        /// <summary>
        /// The type of Logus.
        /// </summary>
        public LoggerType Type { get; set; } = LoggerType.Custom;

        /// <summary>
        /// Setting status to all instances of Logus.
        /// </summary>
        public static Status GlobalStatus { get; set; } = Status.Enabled;

        /// <summary>
        /// Setting status to local instance of Logus.
        /// </summary>
        public Status LocalStatus { get; set; } = Status.Enabled;

        public void Trace(string message, [CallerMemberName] string callerName = "")
        {
            if (GlobalStatus == Status.Enabled && this.LocalStatus == Status.Enabled)
                this.logger.Trace(message, callerName);
        }

        public void Info(string message, [CallerMemberName] string callerName = "")
        {
            if (GlobalStatus == Status.Enabled && this.LocalStatus == Status.Enabled)
                this.logger.Info(message, callerName);
        }

        public void Debug(string message, [CallerMemberName] string callerName = "")
        {
            if (GlobalStatus == Status.Enabled && this.LocalStatus == Status.Enabled)
                this.logger.Debug(message, callerName);
        }

        public void Warning(string message, [CallerMemberName] string callerName = "")
        {
            if (GlobalStatus == Status.Enabled && this.LocalStatus == Status.Enabled)
                this.logger.Warning(message, callerName);
        }

        public void Error(string source, string message, [CallerMemberName] string callerName = "")
        {
            if (GlobalStatus == Status.Enabled && this.LocalStatus == Status.Enabled)
                this.logger.Error(message, callerName);
        }

        public void Error(Exception exception, [CallerMemberName] string callerName = "")
        {
            if (GlobalStatus == Status.Enabled && this.LocalStatus == Status.Enabled)
                this.logger.Error(exception, callerName);
        }

        public void Decide(bool decision, string message, [CallerMemberName] string callerName = "")
        {
            if (GlobalStatus == Status.Enabled && this.LocalStatus == Status.Enabled)
                this.logger.Decide(decision, message, callerName);
        }

        private void AssignLogger()
        {
            switch(this.Type)
            {
                case LoggerType.Custom:
                case LoggerType.Microsoft:
                default:
                    this.logger = new CustomLoggerHandler();
                    break;
            }
        }
    }
}
