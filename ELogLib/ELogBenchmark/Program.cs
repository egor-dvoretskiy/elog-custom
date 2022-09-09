
using BenchmarkDotNet.Running;
using ELogLib;

namespace ELogBenchmark
{
    public class Program
    {
        private static readonly Logus _logger = new Logus();
        
        public static void Main(string[] args)
        {
            _logger.Debug("debug message two three four fifi acpijpj ashdiha kideiwrui ijasdfij ", ELogLib.Enums.PrintLevel.One);
            _logger.Trace("debug message two three four fifi acpijpj ashdiha kideiwrui ijasdfij iahjurfij iajsfdi aisud asdj ijoasjd oij 123 9578239 aslkjdhadhlah 3907490 oasdhfio", ELogLib.Enums.PrintLevel.Two);
            _logger.Info("debug message two three four fifi acpijpj ashdiha kideiwrui ijasdfij iahjurfij iajsfdi aisud asdj ijoasjd oijjasdfij iahjurfij iajsfdi aisud asdj ijoasjd oijjasdfij iahjurfij iajsfdi aisud asdj ijoasjd oij", ELogLib.Enums.PrintLevel.Three);
            
            /*var summary = BenchmarkRunner.Run<ELogBenchmark.Benchmarks.ELogBenchmark>();*/
        }
    }
}
