using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Loggers;
using ELogLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELogBenchmark.Benchmarks
{
    [Config(typeof(Config))]
    [SimpleJob(BenchmarkDotNet.Engines.RunStrategy.ColdStart, launchCount: 5, targetCount: 5, warmupCount: 5)]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public class ELogTests
    {
        private class Config : ManualConfig
        {
            public Config()
            {
                AddLogger(ConsoleLogger.Default);
                AddColumn(TargetMethodColumn.Method, StatisticColumn.Max);
                AddExporter(RPlotExporter.Default, CsvExporter.Default);
                AddAnalyser(EnvironmentAnalyser.Default);
                UnionRule = ConfigUnionRule.AlwaysUseGlobal;
                WithOptions(ConfigOptions.DisableOptimizationsValidator);
            }
        }

        private readonly Logus _logger;

        public const string cntString = "Hello, it's me.";

        public ELogTests()
        {
            this._logger = new Logus();
        }

        [Params(
            "Simple line.",
            $"Interpolated line, {cntString}",
            "big apdosjdpasdnop3412-490kdasdkaslk_++ASD+_A_SDASD+AD!212ojasdstrigndasasdasdat34t34vt3vt4u686769700-90.786m63b532v41        asDASD!+@$!@+#$!@_%#_$^$&*%&*^*(",
            "line with signs \nhello=16\n\rsdad= 12\n\n\t\t24 = 24."
            )]
        public string Message { get; set; }
        /*
                [Params(
                    false, 
                    true
                    )]
                public bool Decision { get; set; }*/


        [Benchmark]
        public void Trace()
        {
            this._logger.Trace(Message, ELogLib.Enums.PrintLevel.One);
        }

        [Benchmark]
        public void Info()
        {
            this._logger.Info(Message, ELogLib.Enums.PrintLevel.Two);
        }

        [Benchmark]
        public void Debug()
        {
            this._logger.Debug(Message, ELogLib.Enums.PrintLevel.Three);
        }

        [Benchmark]
        public void Warning()
        {
            this._logger.Warning(Message, ELogLib.Enums.PrintLevel.Four);
        }

        [Benchmark]
        public void Error()
        {
            this._logger.Error(Message, ELogLib.Enums.PrintLevel.Four);
        }

        [Benchmark]
        public void Decide()
        {
            this._logger.Decide(true, Message, ELogLib.Enums.PrintLevel.Two);
        }
    }
}
