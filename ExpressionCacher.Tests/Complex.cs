#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpressionCacher.Tests.Data;
using NUnit.Framework;

namespace ExpressionCacher.Tests
{
    [TestFixture]
    public class Complex
    {
        [TestCase]
        public void Assert_Per_Properties()
        {
            var expressions = PrepareExpressions<EntityA>()
                .ToList();

            var hashCodes = expressions
                            .Select(ExpressionHasher.GetHashCode)
                            .Distinct();

            Assert.AreEqual(expressions.Count, hashCodes.Count());
        }

        [TestCase]
        public void Assert_Same_Properties_Per_Type_Should_Have_Same_Hashcode()
        {
            var expressions1 = PrepareExpressions<EntityA>()
                               .Select(ExpressionHasher.GetHashCode)
                               .ToList();

            var expressions2 = PrepareExpressions<EntityA>()
                               .Select(ExpressionHasher.GetHashCode)
                               .ToList();

            CollectionAssert.AreEqual(expressions1, expressions2);
        }

        [TestCase]
        public void Assert_Per_Type()
        {
            var expressionsA = PrepareExpressions<EntityA>()
                               .Select(ExpressionHasher.GetHashCode)
                               .OrderBy(it => it)
                               .ToList();

            var expressionsB = PrepareExpressions<EntityB>()
                               .Select(ExpressionHasher.GetHashCode)
                               .OrderBy(it => it)
                               .ToList();

            Assert.AreEqual(expressionsA.Count, expressionsB.Count);

            var distinctHashCodes = expressionsA
                                    .Concat(expressionsB)
                                    .Distinct();

            Assert.AreEqual(expressionsA.Count + expressionsB.Count, distinctHashCodes.Count());
        }

        private IEnumerable<Expression> PrepareExpressions<TEntity>() where TEntity : BaseEntity
        {
            Expression<Func<TEntity, int>> e1 = a => a.Int;

            yield return e1;

            Expression<Func<TEntity, int?>> e2 = a => a.IntNullable;

            yield return e2;

            Expression<Func<TEntity, bool>> e3 = a => a.Boolean;

            yield return e3;

            Expression<Func<TEntity, bool?>> e4 = a => a.BooleanNullable;

            yield return e4;

            Expression<Func<TEntity, string>> e5 = a => a.String;

            yield return e5;

            Expression<Func<TEntity, string?>> e6 = a => a.StringNullable;

            yield return e6;

            Expression<Func<TEntity, long>> e7 = a => a.Long;

            yield return e7;

            Expression<Func<TEntity, long?>> e8 = a => a.LongNullable;

            yield return e8;

            Expression<Func<TEntity, Status>> e9 = a => a.Status;

            yield return e9;

            Expression<Func<TEntity, char>> e10 = a => a.Char;

            yield return e10;

            Expression<Func<TEntity, char?>> e11 = a => a.CharNullable;

            yield return e11;

            Expression<Func<TEntity, BaseEntity.SubEntity>> e12 = a => a.A;

            yield return e12;

            Expression<Func<TEntity, int>> e13 = a => a.A.Id;

            yield return e13;
        }
    }
}