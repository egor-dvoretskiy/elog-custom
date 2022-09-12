using ELogLib;
using EMonolithLib.Extensions.Timing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELogBenchmark.CustomRun
{
    public class ELogTests2
    {
        private readonly Logus _logger;
        private readonly List<string> _args = new List<string>()
        {
            "Simple line.",
            "big apdosjdpasdnop3412-490kdasdkaslk_++ASD+_A_SDASD+AD!212ojasdstrigndasasdasdat34t34vt3vt4u686769700-90.786m63b532v41        asDASD!+@$!@+#$!@_%#_$^$&*%&*^*(",
            "line with signs \nhello=16\n\rsdad= 12\n\n\t\t24 = 24."
        };

        public ELogTests2()
        {
            this._logger = new Logus();
        }

        public void Run()
        {
            this.PrintHeader(this._args[0]);
            this.Test(this._args[0]);

            this.PrintHeader(this._args[1]);
            this.Test(this._args[1]);

            this.PrintHeader(this._args[2]);
            this.Test(this._args[2]);
        }

        public void Test(string msg)
        {
            List<double> resultTest = new List<double>();
            int testCount = 130;

            for (int i = 0; i < testCount; i++)
            {
                this.EvaluateTime(() => this._logger.Info(msg, ELogLib.Enums.PrintLevel.One), out double EvaluatedTimeMS);
                resultTest.Add(EvaluatedTimeMS);
            }

            Console.WriteLine();
            this.PrintResults(resultTest);
            this.PrintAccumulatedResults(resultTest);
        }

        private void PrintAccumulatedResults(List<double> times)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"accumulated time: {times.Average().ToString("f2")} ms.");
            Console.ResetColor();
        }

        private void PrintResults(List<double> times)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            for (int i = 0; i < times.Count; i++)
            {
                Console.WriteLine($"{i}-try: {times[i]} ms.");
            }
            Console.ResetColor();
        }

        private void PrintHeader(string header)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(header);
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
