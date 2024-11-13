using BenchmarkDotNet.Running;
var r = BenchmarkRunner.Run<StringBenchmark.StringTests>(new StringBenchmark.AllowNonOptimized());