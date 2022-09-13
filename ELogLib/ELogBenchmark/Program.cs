
using BenchmarkDotNet.Running;
using ELogBenchmark.CustomRun;
using ELogLib;
using NLog;

namespace ELogBenchmark
{
    public class Program
    {
        private static readonly Logus _logger = new Logus();
        private static readonly ILogger _logger2 = LogManager.GetCurrentClassLogger();
        
        public static void Main(string[] args)
        {
            _logger.Type = ELogLib.Enums.LoggerType.Heavy;

            /*_logger.Debug("debug message two three four fifi acpijpj ashdiha kideiwrui ijasdfij", ELogLib.Enums.PrintLevel.One);
            _logger.Trace("trace message two three four fifi acpijpj ashdiha kideiwrui ijasdfij iahjurfij iajsfdi aisud asdj ijoasjd oij 123 9578239 aslkjdhadhlah 3907490 oasdhfio", ELogLib.Enums.PrintLevel.Two);
            _logger.Info("info message two three four fifi acpijpj ashdiha kideiwrui ijasdfij iahjurfij iajsfdi aisud asdj ijoasjd oijjasdfij iahjurfij iajsfdi aisud asdj ijoasjd oijjasdfij iahjurfij iajsfdi aisud asdj ijoasjd oij", ELogLib.Enums.PrintLevel.Three);
            _logger.Warning("warning ONesolidwordmfas980124jm9aisFBDvcsd9c82oifjc82hdl8cdy72oichu2978ye39oiu2038fjo2ru2oifu0289efjp02iekf2ef2df2", ELogLib.Enums.PrintLevel.Four);
            _logger.Debug("debug darling amazing brilliant terrible kasdhoahjsdouqahdoahsdoahsdkuhaduhasdkauhdkhasidaisduaiusd", ELogLib.Enums.PrintLevel.Two);
            _logger.Info("infosdaid98u12480cu1m0we89u01294uf0rhjf0e28rywde908fy930erhe9f8h20830u02c8ewu2908fjie983h293hf9237y info?", ELogLib.Enums.PrintLevel.One);

            _logger2.Debug("debug message two three four fifi acpijpj ashdiha kideiwrui ijasdfij");
            _logger2.Trace("trace message two three four fifi acpijpj ashdiha kideiwrui ijasdfij iahjurfij iajsfdi aisud asdj ijoasjd oij 123 9578239 aslkdhadhlah 3907490 oasdhfio");
            _logger2.Info("info message two three four fifi acpijpj ashdiha kideiwrui ijasdfij iahjurfij iajsfdi aisud asdj ijoasjd oijjasdfij iahjurfij iajsfdi aisud asdj ijoasjd oijjasdfij iahjurfij iajsfdi aisud asdj ijoasjd oij");
            _logger2.Warn("warning ONesolidwordmfas980124jm9aisFBDvcsd9c82oifjc82hdl8cdy72oichu2978ye39oiu2038fjo2ru2oifu0289efjp02iekf2ef2df2");
            _logger2.Debug("debug darling amazing brilliant terrible kasdhoahjsdouqahdoahsdoahsdkuhaduhasdkauhdkhasidaisduaiusd");
            _logger2.Info("infosdaid98u12480cu1m0we89u01294uf0rhjf0e28rywde908fy930erhe9f8h20830u02c8ewu2908fjie983h293hf9237y info?");*/

            /*_logger2.Warn("kurwa\n\r\tone,\n\r\ttwo");
            _logger2.Debug("just a message.");*/

            /*var summary = BenchmarkRunner.Run<ELogBenchmark.Benchmarks.ELogTests>();*/

            /*ELogTests2 eLogTests2 = new ELogTests2();
            eLogTests2.Run();*/
            NLogTests NLogTesetsdf = new NLogTests();
            NLogTesetsdf.Run();


        }
    }
}
