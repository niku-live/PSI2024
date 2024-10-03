using BenchmarkDotNet.Running;
var r = BenchmarkRunner.Run<Benchmark.BenchmarkRef>(new Benchmark.AllowNonOptimized());