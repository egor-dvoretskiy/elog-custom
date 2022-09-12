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

        public Logus(LoggerType type = LoggerType.Heavy)
        {
            this.Type = type;
            this.AssignLogger();
        }

        /// <summary>
        /// The type of Logus.
        /// </summary>
        public LoggerType Type { get; set; } = LoggerType.Heavy;

        /// <summary>
        /// Setting status to all instances of Logus.
        /// </summary>
        public static Status GlobalStatus { get; set; } = Status.Enabled;

        /// <summary>
        /// Setting status to local instance of Logus.
        /// </summary>
        public Status LocalStatus { get; set; } = Status.Enabled;

        public void Trace(string message, PrintLevel printLevel = PrintLevel.One, [CallerMemberName] string callerName = "")
        {
            if (GlobalStatus == Status.Enabled && this.LocalStatus == Status.Enabled)
                this.logger.Trace(message, printLevel, callerName);
        }

        public void Info(string message, PrintLevel printLevel = PrintLevel.One, [CallerMemberName] string callerName = "")
        {
            if (GlobalStatus == Status.Enabled && this.LocalStatus == Status.Enabled)
                this.logger.Info(message, printLevel, callerName);
        }

        public void Debug(string message, PrintLevel printLevel = PrintLevel.One, [CallerMemberName] string callerName = "")
        {
            if (GlobalStatus == Status.Enabled && this.LocalStatus == Status.Enabled)
                this.logger.Debug(message, printLevel, callerName);
        }

        public void Warning(string message, PrintLevel printLevel = PrintLevel.One, [CallerMemberName] string callerName = "")
        {
            if (GlobalStatus == Status.Enabled && this.LocalStatus == Status.Enabled)
                this.logger.Warning(message, printLevel, callerName);
        }

        public void Error(string message, PrintLevel printLevel = PrintLevel.One, [CallerMemberName] string callerName = "")
        {
            if (GlobalStatus == Status.Enabled && this.LocalStatus == Status.Enabled)
                this.logger.Error(message, printLevel, callerName);
        }

        public void Decide(bool decision, string message, PrintLevel printLevel = PrintLevel.One, [CallerMemberName] string callerName = "")
        {
            if (GlobalStatus == Status.Enabled && this.LocalStatus == Status.Enabled)
                this.logger.Decide(decision, message, printLevel, callerName);
        }

        private void AssignLogger()
        {
            switch(this.Type)
            {
                case LoggerType.Simple:
                    this.logger = new SimpleLogger();
                    break;
                case LoggerType.Heavy:
                default:
                    this.logger = new HeavyLogger();
                    break;
            }
        }
    }
}
