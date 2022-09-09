using ELogLib.Enums;
using ELogLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELogLib.Models
{
    internal class Messager
    {
        private readonly ConsoleColor _timeMessageColor = ConsoleColor.White;
        private readonly int _cursorDividerPosition = 18;

        protected internal static readonly Dictionary<MessageType, string> _typesForPrint = new Dictionary<MessageType, string>()
        {
            { MessageType.Trace, "trc" },
            { MessageType.Debug, "dbg" },
            { MessageType.Error, "err" },
            { MessageType.Warning, "wrn" },
            { MessageType.Info, "inf" }
        };

        protected internal static readonly Dictionary<PrintLevel, int> _consoleOffset = new Dictionary<PrintLevel, int>()
        {
            { PrintLevel.One, 22 },
            { PrintLevel.Two, 30 },
            { PrintLevel.Three, 38 },
            { PrintLevel.Four, 46 },
        };

        public ConsoleColor Color { get; set; }

        public MessageType Type { get; set; }
/*
        public void Print(string message, string callerName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-------------->\t{_typesForPrint[this.Type]}\tCaller Name: {callerName}");
            sb.AppendLine("{");
            sb.AppendLine();
            sb.AppendLine($"{message}");
            sb.AppendLine();
            sb.AppendLine("}");

            Console.ForegroundColor = this.Color;
            Console.WriteLine(sb.ToString());
            Console.ResetColor();
        }*/

        public void Print(string message, PrintLevel printLevel, string callerName)
        {
            Console.SetCursorPosition(0, Console.CursorTop);

            // set info message
            this.PrintColoredMessage($"[{DateTime.Now.ToString("HH:mm:ss")}]{_typesForPrint[this.Type]}", ConsoleColor.White);
            /*this.SetDivider();*/
            // -

            // parse string into lines if neccessary
            var list = this.DisassembleMessage(message);
            // -

            this.PrintDisassamledMessage(list, printLevel);
        }

        private void PrintColoredMessage(string message, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(message);
            Console.ResetColor();
        }

        private void SetDivider()
        {
            Console.SetCursorPosition(this._cursorDividerPosition, Console.CursorTop);
            this.PrintColoredMessage("|", this._timeMessageColor);
        }

        private void PrintDisassamledMessage(List<string> lines, PrintLevel printLevel)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                this.SetDivider();
                Console.SetCursorPosition(_consoleOffset[printLevel], Console.CursorTop);
                this.PrintColoredMessage(lines[i], this.Color);
                Console.SetCursorPosition(_consoleOffset[printLevel], Console.CursorTop + 1);
            }
        }

        private List<string> DisassembleMessage(string message)
        {
            int availableAmountOfSymbols = Console.WindowWidth - Console.CursorLeft;
            List<string> disassemledMessage = new List<string>();

            string[] words = message.Split(' ');

            int localSymbolsAmount = 0;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                if (localSymbolsAmount + words[i].Length >= availableAmountOfSymbols || i == words.Length - 1)
                {
                    disassemledMessage.Add(stringBuilder.ToString());
                    
                    localSymbolsAmount = 0;
                    stringBuilder.Clear();
                }

                if (i != words.Length - 1)
                {
                    localSymbolsAmount += words[i].Length;
                    stringBuilder.Append(words[i]);
                }
            }

            return disassemledMessage;
        }
    }
}
