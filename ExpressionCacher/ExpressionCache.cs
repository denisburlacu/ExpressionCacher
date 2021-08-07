using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace ExpressionCacher
{
    public static class ExpressionCache
    {
        private static readonly ConcurrentDictionary<int, object> Cache = new();

        public static Func<TIn, TOut> ToFunc<TIn, TOut>(this Expression<Func<TIn, TOut>> expression)
        {
            var cacheKey = ExpressionHasher.GetHashCode(expression);

            return Cache.GetOrAdd(cacheKey, exp => expression.Compile()) as Func<TIn, TOut> ?? expression.Compile();
        }
    }
}