using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ELogLib.Interfaces
{
    public interface ILog
    {
        /// <summary>
        /// Contain the most detailed messages. These messages may contain sensitive app data. These messages are disabled by default and should not be enabled in production.
        /// </summary>
        /// <param name="message">Standart log message.</param>
        void Trace(string message, [CallerMemberName] string callerName = "");

        /// <summary>
        /// For debugging and development. Use with caution in production due to the high volume.
        /// </summary>
        /// <param name="message">Standart log message.</param>
        void Info(string message, [CallerMemberName] string callerName = "");

        /// <summary>
        /// Tracks the general flow of the app. May have long-term value.
        /// </summary>
        /// <param name="message">Standart log message.</param>
        void Debug(string message, [CallerMemberName] string callerName = "");

        /// <summary>
        /// For abnormal or unexpected events. Typically includes errors or conditions that don't cause the app to fail.
        /// </summary>
        /// <param name="message">Standart log message.</param>
        void Warning(string message, [CallerMemberName] string callerName = "");

        /// <summary>
        /// For errors and exceptions that cannot be handled. These messages indicate a failure in the current operation or request, not an app-wide failure.
        /// For failures that require immediate attention. Examples: data loss scenarios, out of disk space.
        /// </summary>
        /// <param name="source">Source of error.</param>
        /// <param name="message">Standart log message.</param>
        void Error(string source, string message, [CallerMemberName] string callerName = "");

        /// <summary>
        /// For errors and exceptions that cannot be handled. These messages indicate a failure in the current operation or request, not an app-wide failure.
        /// For failures that require immediate attention. Examples: data loss scenarios, out of disk space.
        /// </summary>
        /// <param name="exception">Poped up exception.</param>
        void Error(Exception exception, [CallerMemberName] string callerName = "");

        /// <summary>
        /// Decides to log between Info and Warning.
        /// </summary>
        /// <param name="decision">Boolean value that helps to make a decision.</param>
        /// <param name="message">Standart log message.</param>
        void Decide(bool decision, string message, [CallerMemberName] string callerName = "");
    }
}
