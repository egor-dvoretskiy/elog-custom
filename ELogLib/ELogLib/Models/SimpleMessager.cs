using ELogLib.Enums;
using ELogLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELogLib.Models
{
    internal class SimpleMessager
    {
        public ConsoleColor Color { get; set; }

        public MessageType Type { get; set; }

        public void Print(string message)
        {
            Console.ForegroundColor = this.Color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
