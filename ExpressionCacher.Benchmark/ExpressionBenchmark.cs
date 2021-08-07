using System;
using System.Linq.Expressions;
using BenchmarkDotNet.Attributes;

namespace ExpressionCacher.Benchmark
{
    public class ExpressionBenchmark
    {
        private readonly Product _product;

        public ExpressionBenchmark()
        {
            _product = new Product()
                      {
                          Id = 1,
                          Name = "Test1"
                      };
        }

        [Benchmark]
        public string RegularProperty()
        {
            return _product.Name;
        }

        [Benchmark]
        public string Compile()
        {
            Expression<Func<Product, string>> expression = product1 => product1.Name;

            return expression.Compile()(_product);
        }
        
        [Benchmark]
        public string ExpressionCacher()
        {
            Expression<Func<Product, string>> expression = product1 => product1.Name;

            return expression.ToFunc()(_product);
        }
    }
}