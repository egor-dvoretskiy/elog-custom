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
        private readonly ErrorMessager _errorMessager;
        private readonly Messager _warningMessager;

        public CustomLoggerHandler()
        {
            this._debugMessager = new Messager()
            {
                Color = ConsoleColor.White,
                Type = MessageType.Debug
            };

            this._errorMessager = new ErrorMessager()
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

        /// <inheritdoc/>
        public void Debug(string message, [CallerMemberName] string callerName = "")
        {
            this._debugMessager?.Print(message, callerName);
        }

        public void Decide(bool decision, string message, [CallerMemberName] string callerName = "")
        {
            if (decision)
                this.Info(string.Concat(message, "\t| Success."), callerName);
            else
                this.Warning(string.Concat(message, "\t| Fail."), callerName);
        }

        /// <inheritdoc/>
        public void Error(string source, string message, [CallerMemberName] string callerName = "")
        {
            this._errorMessager?.Print(source, message, callerName);
        }

        /// <inheritdoc/>
        public void Info(string message, [CallerMemberName] string callerName = "")
        {
            this._infoMessager?.Print(message, callerName);
        }

        /// <inheritdoc/>
        public void Trace(string message, [CallerMemberName] string callerName = "")
        {
            this._traceMessager?.Print(message, callerName);
        }

        /// <inheritdoc/>
        public void Warning(string message, [CallerMemberName] string callerName = "")
        {
            this._warningMessager?.Print(message, callerName);
        }
    }
}
