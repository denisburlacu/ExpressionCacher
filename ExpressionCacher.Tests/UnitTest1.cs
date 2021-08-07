using System;
using System.Linq.Expressions;
using NUnit.Framework;

namespace ExpressionCacher.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Expression<Func<Product, string>> expression = product => product.Name;

            var product = new Product()
                          {
                              Id = 1,
                              Name = "32"
                          };
            
            Assert.AreEqual(product.Name, expression.Compile()(product));
            Assert.AreEqual(product.Name, expression.ToFunc()(product));
            
            Assert.Pass();
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}