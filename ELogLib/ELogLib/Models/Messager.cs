using ELogLib.Enums;
using ELogLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELogLib.Models
{
    internal class Messager : IMessage
    {
        protected internal static readonly Dictionary<MessageType, string> _typesForPrint = new Dictionary<MessageType, string>()
        {
            { MessageType.Trace, "trc" },
            { MessageType.Debug, "dbg" },
            { MessageType.Error, "err" },
            { MessageType.Warning, "wrn" },
            { MessageType.Info, "inf" }
        };

        public ConsoleColor Color { get; set; }

        public MessageType Type { get; set; }

        public void Print(string message, string callerName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{_typesForPrint[this.Type]}{Environment.NewLine}\tCaller Name: {callerName}");
            sb.AppendLine("{");
            sb.AppendLine($"{message}");
            sb.AppendLine("}");

            Console.ForegroundColor = this.Color;
            Console.WriteLine(sb.ToString());
            Console.ResetColor();
        }
    }
}
