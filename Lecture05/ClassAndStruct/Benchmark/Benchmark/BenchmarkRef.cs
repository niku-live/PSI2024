﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Validators;
using BenchmarkDotNet.Configs;
using System.Text;
using BenchmarkDotNet.Jobs;

namespace Benchmark
{
    public class AllowNonOptimized : ManualConfig
    {
        public AllowNonOptimized()
        {
            AddValidator(JitOptimizationsValidator.DontFailOnError); // ALLOW NON-OPTIMIZED DLLS

            AddLogger(DefaultConfig.Instance.GetLoggers().ToArray()); // manual config has no loggers by default
            AddExporter(DefaultConfig.Instance.GetExporters().ToArray()); // manual config has no exporters by default
            AddColumnProvider(DefaultConfig.Instance.GetColumnProviders().ToArray()); // manual config has no columns by default
        }
    }

    [RankColumn, MinColumn, MaxColumn, StdDevColumn, MedianColumn]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net481)]
    [HtmlExporter, MarkdownExporter]
    [MemoryDiagnoser]
    public class BenchmarkRef
    {
        public class C1
        {
            public string Text1;
            public string Text2;
            public string Text3;
        }

        public struct S1
        {
            public string Text1;
            public string Text2;
            public string Text3;
        }

        List<C1> testListClass = new List<C1>();
        List<S1> testListStruct = new List<S1>();
        C1[] testArrayClass;
        S1[] testArrayStruct;
        public BenchmarkRef()
        {
            for(int i=0;i<1000;i++)
            {
                testListClass.Add(new C1  { Text1= i.ToString(), Text2=null, Text3= i.ToString() });
                testListStruct.Add(new S1 { Text1 = i.ToString(), Text2 = null, Text3 = i.ToString() });
            }
            testArrayClass = testListClass.ToArray();
            testArrayStruct = testListStruct.ToArray();
        }

        [Benchmark]
        public int TestListClass()
        {
            var x = 0;
            foreach(var i in testListClass)
            {
                x += i.Text1.Length + i.Text3.Length;
            }
            return x;
        }

        [Benchmark]
        public int TestArrayClass()
        {
            var x = 0;
            foreach (var i in testArrayClass)
            {
                x += i.Text1.Length + i.Text3.Length;
            }
            return x;
        }

        [Benchmark]
        public int TestListStruct()
        {
            var x = 0;
            foreach (var i in testListStruct)
            {
                x += i.Text1.Length + i.Text3.Length;
            }
            return x;
        }

        [Benchmark]
        public int TestArrayStruct()
        {
            var x = 0;
            foreach (var i in testArrayStruct)
            {
                x += i.Text1.Length + i.Text3.Length;
            }
            return x;
        }

        [Benchmark]
        public int TestLinqClass()
        {
            var x = testListClass.Select(i=> i.Text1.Length + i.Text3.Length).Sum();
            return x;
        }

        [Benchmark]
        public int TestLinqStruct()
        {
            var x = testListStruct.Select(i => i.Text1.Length + i.Text3.Length).Sum();
            return x;
        }
    }
}
