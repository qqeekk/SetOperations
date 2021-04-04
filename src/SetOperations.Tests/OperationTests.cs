using System;
using System.Collections.Generic;
using Bogus;
using Xunit;

namespace SetOperations.Tests
{
    /// <summary>
    /// Test fixture
    /// </summary>
    public partial class OperationTests
    {
        [Theory]
        [MemberData(nameof(EqualityData))]
        public void EqualityTest(object[] a, object[] b, bool result)
        {
            var aEqualsB = a.IsSetEquals(b);
            var bEqualsA = b.IsSetEquals(a);

            Assert.Equal(aEqualsB, bEqualsA);
            Assert.Equal(aEqualsB, result);
        }

        [Theory]
        [MemberData(nameof(IntersectionData))]
        public void IntersectionTest(object[] a, object[] b, HashSet<object> res)
        {
            var aIntersectionB = a.GetIntersection(b);
            var bIntersectionA = b.GetIntersection(a);

            Assert.True(aIntersectionB.IsSetEquals(bIntersectionA));
            Assert.True(aIntersectionB.IsSetEquals(res));
        }

        [Theory]
        [MemberData(nameof(UnionData))]
        public void UnionTest(object[] a, object[] b, HashSet<object> res)
        {
            var aUnionB = a.GetUnion(b);
            var bUnionA = b.GetUnion(a);

            Assert.True(aUnionB.IsSetEquals(bUnionA));
            Assert.True(aUnionB.IsSetEquals(res));
        }

        [Theory]
        [MemberData(nameof(DifferenceData))]
        public void DifferenceTest(object[] a, object[] b, HashSet<object> res)
        {
            var difference = a.GetDifference(b);
            Assert.True(difference.IsSetEquals(res));
        }

        [Fact]
        public void SelfEqualityTest()
        {
            var faker = new Faker();
            for (var i = 0; i < 5; i++)
            {
                var source = faker.Random.ArrayElements(alphabet, 8);
                Assert.True(source.IsSetEquals(source));
            }
        }

        [Fact]
        public void SymmetricDifferenceEqualsToUnionExceptIntersectionTest()
        {
            var faker = new Faker();
            for (var i = 0; i < 5; i++)
            {
                var a = faker.Random.ArrayElements(alphabet, 40);
                var b = faker.Random.ArrayElements(alphabet, 40);

                var union = a.GetUnion(b);
                var intersection = a.GetIntersection(b);
                var symmetricDifference = a.GetSymmetricDifference(b);

                Assert.True(union.GetDifference(intersection).IsSetEquals(symmetricDifference));
            }
        }

        [Fact]
        public void SubsetNotEqualToSetTest()
        {
            var faker = new Faker();
            for (var i = 0; i < 5; i++)
            {
                var source = faker.Random.ArrayElements(alphabet, 8);
                Assert.False(source.IsSetProperSubsetOf(source));
            }
        }

        [Fact]
        public void SourceNotMutatedTest()
        {
            var source = new[] { 1, 2, 3 };
            _ = source.GetDifference(new[] { 1 });

            Assert.Contains(1, source);
        }

        [Fact]
        public void TypesNotCastedTest()
        {
            var first = new[] { 5 };
            var second = new[] { 5.0m };

            Assert.False(first.IsSetEquals(second));
            Assert.Empty(first.GetIntersection(second));
        }

        [Fact]
        public void TolerateNullsTest()
        {
            var first = new object[] { 1, null };
            var second = new object[] { 2, null };

            Assert.Equal(3, first.GetUnion(second).Count);
            Assert.Equal(1, first.GetIntersection(second).Count);
            Assert.Contains(null, first.GetIntersection(second));
        }
    }
}
