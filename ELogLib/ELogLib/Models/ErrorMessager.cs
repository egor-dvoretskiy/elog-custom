using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELogLib.Models
{
    internal class ErrorMessager : Messager
    {
        public void Print(Exception exception, string callerName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-------------->\t{_typesForPrint[this.Type]}\tCaller Name: {callerName}");
            sb.AppendLine("{");
            sb.AppendLine();
            sb.AppendLine($"Exception Source: {exception.Source}");
            sb.AppendLine($"Exception Message: {exception.Message}");
            sb.AppendLine();
            sb.AppendLine("}");

            Console.ForegroundColor = this.Color;
            Console.Write(sb.ToString());
            Console.ResetColor();
        }
    }
}
