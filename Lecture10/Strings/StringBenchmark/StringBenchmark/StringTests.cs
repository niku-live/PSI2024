using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Validators;
using BenchmarkDotNet.Configs;
using System.Text;

namespace StringBenchmark
{
    public class AllowNonOptimized : ManualConfig
    {
        public AllowNonOptimized()
        {
            Add(JitOptimizationsValidator.DontFailOnError); // ALLOW NON-OPTIMIZED DLLS

            Add(DefaultConfig.Instance.GetLoggers().ToArray()); // manual config has no loggers by default
            Add(DefaultConfig.Instance.GetExporters().ToArray()); // manual config has no exporters by default
            Add(DefaultConfig.Instance.GetColumnProviders().ToArray()); // manual config has no columns by default
        }
    }

    public class StringTests
    {
        [Params(2, 10, 100, 1_000, 10_000)]
        public int ConcatCount { get; set; }

        [Benchmark]
        public void AsString()
        {
            var s = "";
            for (int i = 0; i < ConcatCount; i++)
            {
                s += "0";
            }
            int len = s.Length;
        }

        [Benchmark]
        public void AsStringBuilder()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < ConcatCount; i++)
            {
                sb.Append("0");
            }
            var s = sb.ToString();
            int len = s.Length;
        }
    }
}
