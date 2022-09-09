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
    internal class CustomLoggerHandler : ILog
    {
        private readonly Messager _debugMessager;
        private readonly Messager _traceMessager;
        private readonly Messager _infoMessager;
        private readonly Messager _errorMessager;
        private readonly Messager _warningMessager;

        public CustomLoggerHandler()
        {
            this._debugMessager = new Messager()
            {
                Color = ConsoleColor.White,
                Type = MessageType.Debug
            };

            this._errorMessager = new Messager()
            {
                Color = ConsoleColor.Red,
                Type = MessageType.Error
            };

            this._traceMessager = new Messager()
            {
                Color = ConsoleColor.Gray,
                Type = MessageType.Trace
            };

            this._warningMessager = new Messager()
            {
                Color = ConsoleColor.Yellow,
                Type = MessageType.Warning
            };

            this._infoMessager = new Messager()
            {
                Color = ConsoleColor.Green,
                Type = MessageType.Info
            };
        }

        public void Debug(string message, PrintLevel printLevel = PrintLevel.One, [CallerMemberName] string callerName = "")
        {
            /*this._debugMessager?.Print(message, callerName);*/
            this._debugMessager?.Print(message, printLevel, callerName);
        }

        public void Decide(bool decision, string message, PrintLevel printLevel = PrintLevel.One, [CallerMemberName] string callerName = "")
        {
            if (decision)
                this.Info(string.Concat(message, "\t| Success."), printLevel, callerName);
            else
                this.Warning(string.Concat(message, "\t| Fail."), printLevel, callerName);
        }

        public void Error(string message, PrintLevel printLevel = PrintLevel.One, [CallerMemberName] string callerName = "")
        {
            this._errorMessager?.Print(message, printLevel, callerName);
        }

        public void Info(string message, PrintLevel printLevel = PrintLevel.One, [CallerMemberName] string callerName = "")
        {
            this._infoMessager?.Print(message, printLevel, callerName);
        }

        public void Trace(string message, PrintLevel printLevel = PrintLevel.One, [CallerMemberName] string callerName = "")
        {
            this._traceMessager?.Print(message, printLevel, callerName);
        }

        public void Warning(string message, PrintLevel printLevel = PrintLevel.One, [CallerMemberName] string callerName = "")
        {
            this._warningMessager?.Print(message, printLevel, callerName);
        }
    }
}
