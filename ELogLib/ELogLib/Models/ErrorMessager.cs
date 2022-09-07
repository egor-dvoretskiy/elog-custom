using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELogLib.Models
{
    internal class ErrorMessager : Messager
    {
        public void Print(string source, string message, string callerName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-------------->\t{_typesForPrint[this.Type]}\tCaller Name: {callerName}");
            sb.AppendLine("{");
            sb.AppendLine();
            sb.AppendLine($"Error Source: {source}");
            sb.AppendLine($"Error Message: {message}");
            sb.AppendLine();
            sb.AppendLine("}");

            Console.ForegroundColor = this.Color;
            Console.Write(sb.ToString());
            Console.ResetColor();
        }
    }
}
