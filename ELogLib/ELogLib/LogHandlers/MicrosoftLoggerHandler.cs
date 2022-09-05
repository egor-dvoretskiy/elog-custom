using ELogLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELogLib.LogHandlers
{
    /*internal class MicrosoftLoggerHandler<T> : ILog
        {
            private readonly ILogger<T> _logger;

            /// <summary>
            /// Constructor generates inner logger through the logger factory.
            /// </summary>
            public MicrosoftLoggerHandler()
            {
                var loggerFactory = LoggerFactory.Create(builder => builder
                                                                        .AddConsole()
                                                                        .AddDebug()
                                                                        .SetMinimumLevel(LogLevel.Trace));

                _logger = loggerFactory.CreateLogger<T>();
            }

            /// <inheritdoc/>
            public void Debug(string message)
            {
                _logger.LogDebug(message);
            }

            public void Decide(bool decision, string message)
            {
                if (decision)
                    this.Info(string.Concat(message, "| Success."));
                else
                    this.Warning(string.Concat(message, "| Fail."));
            }

            /// <inheritdoc/>
            public void Error(string source, string message)
            {
                string errorMessage = string.Concat(source, ": ", message);
                _logger.LogError(errorMessage);
            }

            /// <inheritdoc/>
            public void Info(string message)
            {
                _logger.LogInformation(message);
            }

            /// <inheritdoc/>
            public void Trace(string message)
            {
                _logger.LogTrace(message);
            }

            /// <inheritdoc/>
            public void Warning(string message)
            {
                _logger.LogWarning(message);
            }
        }*/
}
