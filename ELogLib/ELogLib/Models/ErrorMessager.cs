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
            sb.AppendLine($"{_typesForPrint[this.Type]}\t{Environment.NewLine}Exception Source: {exception.Source}");
            sb.AppendLine($"\tCaller Name: {callerName}");
            sb.AppendLine($"\tException Message: {exception.Message}");

            Console.ForegroundColor = this.Color;
            Console.Write(sb.ToString());
            Console.ResetColor();
        }
    }
}
