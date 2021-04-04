using System;
using System.Collections.Generic;
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
        public void EqualityTest(object[] a, object[] b)
        {
        }

        [Theory]
        [MemberData(nameof(IntersectionData))]
        public void IntersectionTest(object[] a, object[] b, HashSet<object> res)
        {
        }

        [Theory]
        [MemberData(nameof(UnionData))]
        public void UnionTest(object[] a, object[] b, HashSet<object> res)
        {
        }

        [Theory]
        [MemberData(nameof(DifferenceData))]
        public void DifferenceTest(object[] a, object[] b, HashSet<object> res)
        {
        }

        [Fact]
        public void DifferenceEqualsToUnionExceptIntersectionTest()
        {
        }

        [Fact]
        public void SubsetNotEqualToSetTest()
        {
        }

        [Fact]
        public void SourceNotMutatedTest()
        {
        }

        [Fact]
        public void TypesNotCastedTest()
        {
        }

        [Fact]
        public void TolerateNullsTest()
        {
        }
    }
}
