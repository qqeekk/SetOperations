using System;
using System.Collections.Generic;
using System.Text;

namespace SetOperations.Tests
{
    public partial class OperationTests
    {
        public static IEnumerable<object[]> EqualityData()
        {
            yield return new object[2];
        }

        public static IEnumerable<object[]> IntersectionData()
        {
            yield return new object[3];
        }

        public static IEnumerable<object[]> UnionData()
        {
            yield return new object[3];
        }

        public static IEnumerable<object[]> DifferenceData()
        {
            yield return new object[3];
        }
    }
}
