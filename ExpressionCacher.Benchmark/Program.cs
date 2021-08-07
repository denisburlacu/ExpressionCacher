using System;
using System.Linq.Expressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ExpressionCacher.Benchmark
{
    public class ExpressionBenchmark
    {
        private const int N = 10000;
        private readonly Product product;


        public ExpressionBenchmark()
        {
            product = new Product()
                      {
                          Id = 1,
                          Name = "Test1"
                      };
        }

        [Benchmark]
        public string RegularProperty()
        {
            return product.Name;
        }

        [Benchmark]
        public string Compile()
        {
            Expression<Func<Product, string>> expression = product1 => product1.Name;

            return expression.Compile()(product);
        }
        
        [Benchmark]
        public string ExpressionCacher()
        {
            Expression<Func<Product, string>> expression = product1 => product1.Name;

            return expression.ToFunc()(product);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ExpressionBenchmark>();
            Console.WriteLine(summary);
        }
    }
    
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}