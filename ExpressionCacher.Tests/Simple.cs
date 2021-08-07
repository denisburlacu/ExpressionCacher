using System;
using System.Linq.Expressions;
using NUnit.Framework;

namespace ExpressionCacher.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Expression<Func<Product, string?>> expression = product => product.Name;

            var product = new Product()
                          {
                              Id = 1,
                              Name = "32"
                          };

            Assert.AreEqual(product.Name, expression.Compile()(product));
            Assert.AreEqual(product.Name, expression.ToFunc()(product));
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}