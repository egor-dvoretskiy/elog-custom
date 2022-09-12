using ELogLib.Enums;
using ELogLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELogLib.Models
{
    internal class HeavyMessager
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

        public void Print(string message, PrintLevel printLevel, string callerName)
        {
            Console.SetCursorPosition(0, Console.CursorTop);

            // set info message
            this.PrintDateTimeInfo();
            // -

            // parse string into lines if neccessary
            var list = this.DisassembleMessage(message, printLevel);
            // -

            this.PrintDisassamledMessage(list, printLevel);
        }

        private void PrintDateTimeInfo()
        {
            this.PrintColoredMessage($"[{DateTime.Now.ToString("HH:mm:ss")}]", ConsoleColor.White);
            this.PrintColoredMessage($"{_typesForPrint[this.Type]}", this.Color);
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
                Console.CursorTop++;
            }
        }

        private List<string> DisassembleMessage(string message, PrintLevel printLevel)
        {
            int cursorLeft = _consoleOffset is null ? Console.CursorLeft : _consoleOffset[printLevel];
            int availableAmountOfSymbols = Console.WindowWidth - cursorLeft;

            StringBuilder stringBuilder = new StringBuilder();
            List<string> lines = new List<string>();
            string[] words = message.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                int inlineAvailableSymbols = availableAmountOfSymbols - stringBuilder.Length;

                if (words[i].Length <= inlineAvailableSymbols)
                {
                    stringBuilder.Append(words[i]);
                    stringBuilder.Append(" ");
                    continue;
                }

                if (words[i].Length > availableAmountOfSymbols)
                {
                    int restWordLength = words[i].Length;
                    int currentIndex = 0;

                    while (restWordLength > availableAmountOfSymbols)
                    {
                        string word = words[i].Substring(currentIndex, availableAmountOfSymbols - stringBuilder.Length);
                        stringBuilder.Append(word);
                        currentIndex += availableAmountOfSymbols;
                        restWordLength -= availableAmountOfSymbols;

                        lines.Add(stringBuilder.ToString());
                        stringBuilder.Clear();
                    }

                    string restWord = words[i].Substring(currentIndex, restWordLength);

                    stringBuilder.Append(restWord);
                }
                else
                {
                    lines.Add(stringBuilder.ToString());
                    stringBuilder.Clear();

                    stringBuilder.Append(words[i]);
                }

                stringBuilder.Append(" ");
            }

            lines.Add(stringBuilder.ToString());
            stringBuilder.Clear();

            return lines;
        }
    }
}
