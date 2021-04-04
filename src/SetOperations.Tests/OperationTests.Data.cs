using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SetOperations.Tests
{
    public partial class OperationTests
    {
        private static readonly object[] alphabet;

        static OperationTests()
        {
            Randomizer.Seed = new Random(578347232);

            var faker = new Faker("en");
            var bytes = faker.Random.Bytes(count: 15).OfType<object>();
            var words = faker.Random.WordsArray(count: 15).OfType<object>();
            var chars = faker.Random.Chars(count: 15).OfType<object>();
            var dates = Enumerable.Range(1, 15).Select(_ => (object)faker.Date.Past(yearsToGoBack: 20));

            alphabet = bytes.Concat(words).Concat(chars).Concat(dates).ToArray();
        }

        public static IEnumerable<object[]> EqualityData()
        {
            yield return new object[]
            {
                new object[0],
                new object[0],
                true
            };

            yield return new object[]
            {
                new object[] { 1, 1 },
                new object[] { 1 },
                true
            };

            yield return new object[]
            {
                new object[] { 1, 2 },
                new object[] { 2, 1 },
                true
            };

            yield return new object[]
            {
                new object[] { 1, "abc", 2 },
                new object[] { 1, 2, 2, "abc" },
                true
            };

            yield return new object[]
            {
                new object[] { 1, "abc", 2 },
                new object[] { 1, 2.0, "abc" },
                false
            };
        }

        public static IEnumerable<object[]> IntersectionData()
        {
            yield return new object[]
            {
                new object[] { 1, 1, 1 },
                new object[] { 1, 1 },
                new object[] { 1 }.ToHashSet()
            };

            yield return new object[]
            {
                new object[] { 1, "abc", 2 },
                new object[] { 1, 3, 2.0, "abc" },
                new object[] { 1, "abc" }.ToHashSet()
            };

            yield return new object[]
            {
                new object[] { 1, "abc", 2 },
                new object[] { 3, "ABC" },
                new HashSet<object>()
            };
        }

        public static IEnumerable<object[]> UnionData()
        {
            yield return new object[]
            {
                new object[0],
                new object[1],
                new object[] { null }.ToHashSet(),
            };

            yield return new object[]
            {
                new object[] { 1, 1 },
                new object[] { 2 },
                new object[] { 1, 2 }.ToHashSet()
            };

            yield return new object[]
            {
                new object[] { 1, "abc", 2 },
                new object[] { 1, 3, 2.0, "abc" },
                new object[] { 1, 2, 2.0, 3, "abc" }.ToHashSet()
            };
        }

        public static IEnumerable<object[]> DifferenceData()
        {
            yield return new object[]
            {
                new object[] { 1, 2 },
                new object[] { 1, 2, 3 },
                new HashSet<object>()
            };

            yield return new object[]
            {
                new object[] { 1, "abc", 2 },
                new object[] { 1, 3, 2.0, "abc" },
                new object[] { 2 }.ToHashSet()
            };
        }
    }
}
