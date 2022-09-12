using ELogLib.Enums;
using ELogLib.Interfaces;
using ELogLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ELogLib.LogHandlers
{
    internal class SimpleLogger : ILog
    {
        private readonly SimpleMessager _debugMessager;
        private readonly SimpleMessager _traceMessager;
        private readonly SimpleMessager _infoMessager;
        private readonly SimpleMessager _errorMessager;
        private readonly SimpleMessager _warningMessager;

        public SimpleLogger()
        {
            this._debugMessager = new SimpleMessager()
            {
                Color = ConsoleColor.White,
                Type = MessageType.Debug
            };

            this._errorMessager = new SimpleMessager()
            {
                Color = ConsoleColor.Red,
                Type = MessageType.Error
            };

            this._traceMessager = new SimpleMessager()
            {
                Color = ConsoleColor.Gray,
                Type = MessageType.Trace
            };

            this._warningMessager = new SimpleMessager()
            {
                Color = ConsoleColor.Yellow,
                Type = MessageType.Warning
            };

            this._infoMessager = new SimpleMessager()
            {
                Color = ConsoleColor.Green,
                Type = MessageType.Info
            };
        }

        public void Debug(string message, PrintLevel printLevel = PrintLevel.One, [CallerMemberName] string callerName = "")
        {
            this._debugMessager.Print(message);
        }

        public void Decide(bool decision, string message, PrintLevel printLevel = PrintLevel.One, [CallerMemberName] string callerName = "")
        {
            if (decision)
                this.Info(string.Concat(message, "\t| Success."));
            else
                this.Warning(string.Concat(message, "\t| Fail."));
        }

        public void Error(string message, PrintLevel printLevel = PrintLevel.One, [CallerMemberName] string callerName = "")
        {
            this._errorMessager.Print(message);
        }

        public void Info(string message, PrintLevel printLevel = PrintLevel.One, [CallerMemberName] string callerName = "")
        {
            this._infoMessager.Print(message);
        }

        public void Trace(string message, PrintLevel printLevel = PrintLevel.One, [CallerMemberName] string callerName = "")
        {
            this._traceMessager.Print(message);
        }

        public void Warning(string message, PrintLevel printLevel = PrintLevel.One, [CallerMemberName] string callerName = "")
        {
            this._warningMessager.Print(message);
        }
    }
}
