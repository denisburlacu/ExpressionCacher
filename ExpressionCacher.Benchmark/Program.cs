using System;
using BenchmarkDotNet.Running;

namespace ExpressionCacher.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ExpressionBenchmark>();
            Console.WriteLine(summary);
        }
    }
}