﻿using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace ExpressionCacher
{
    public static class ExpressionCache
    {
        private static readonly ConcurrentDictionary<int, object> _cache = new();

        public static Func<TIn, TOut> ToFunc<TIn, TOut>(this Expression<Func<TIn, TOut>> expression)
        {
            var cacheKey = ExpressionHasher.GetHashCode(expression);

            return _cache.GetOrAdd(cacheKey, exp => expression.Compile()) as Func<TIn, TOut> ?? throw new InvalidOperationException();
        }
    }
}