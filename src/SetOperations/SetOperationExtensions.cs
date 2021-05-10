using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SetOperations
{
    /// <summary>
    /// Set extensions.
    /// </summary>
    public static class SetOperationExtensions
    {
        /// <summary>
        /// Gets the union set of 2 sequences. The union should have all elements from both sequences one time for each.
        /// </summary>
        /// <param name="first">First set.</param>
        /// <param name="second">Second set.</param>
        /// <returns>The union.</returns>
        public static ISet<object> GetUnion(this IEnumerable first, IEnumerable second)
            => MakeSet(first).Tee(set => set.UnionWith(MakeGeneric(second)));

        /// <summary>
        /// Gets the intersection set of 2 sequences. The intersection should have only the elements that occurr in both sequences.
        /// </summary>
        /// <param name="first">First set.</param>
        /// <param name="second">Second set.</param>
        /// /// <returns>The intersection.</returns>
        public static ISet<object> GetIntersection(this IEnumerable first, IEnumerable second)
            => MakeSet(first).Tee(set => set.IntersectWith(MakeGeneric(second)));

        /// <summary>
        /// Gets the difference set of 2 sequences. 
        /// The difference should have only those elements that occurr in the first sequence but not in the second.
        /// </summary>
        /// <param name="first">First set.</param>
        /// <param name="second">Second set.</param>
        /// <returns>The difference.</returns>
        public static ISet<object> GetDifference(this IEnumerable first, IEnumerable second)
            => MakeSet(first).Tee(set => set.ExceptWith(MakeGeneric(second)));

        /// <summary>
        /// Gets the symmetric difference set of 2 sequences. 
        /// The symmetric difference should have only elements contained in union except those contined in intersection.
        /// </summary>
        /// <param name="first">First set.</param>
        /// <param name="second">Second set.</param>
        /// <returns>The symmetric difference.</returns>
        public static ISet<object> GetSymmetricDifference(this IEnumerable first, IEnumerable second)
            => MakeSet(first).Tee(set => set.SymmetricExceptWith(MakeGeneric(second)));

        /// <summary>
        /// Returns true if the second sequence is a proper subset of the first.
        /// Set "second" is called a 'proper subset' of set "first" if set "second" is fully contained in set "first" and "first" != "second".
        /// </summary>
        /// <param name="first">First set.</param>
        /// <param name="second">Second set.</param>
        /// <returns>Result.</returns>
        public static bool IsSetProperSubsetOf(this IEnumerable first, IEnumerable second)
            => MakeSet(first).IsProperSubsetOf(MakeGeneric(second));

        /// <summary>
        /// Returns true if the first sequence equals the second.
        /// Equality means set "first" contains all elements from set "second" and set "second" contains all elements from set "first"
        /// </summary>
        /// <param name="first">First set.</param>
        /// <param name="second">Second set.</param>
        /// <returns>Result.</returns>
        public static bool IsSetEquals(this IEnumerable first, IEnumerable second)
            => MakeSet(first).SetEquals(MakeGeneric(second));

        /// <summary>
        /// Executes side-effect on param and then returns param.
        /// </summary>
        /// <param name="param">Param.</param>
        /// <param name="action">Action.</param>
        /// <returns>Param.</returns>
        private static T Tee<T>(this T param, Action<T> action)
        {
            action(param);
            return param;
        }

        private static IEnumerable<object> MakeGeneric(IEnumerable seq)
            => seq as IEnumerable<object> ?? seq.OfType<object>();

        private static ISet<object> MakeSet(IEnumerable seq)
        {
            var seq1 = MakeGeneric(seq);

            return seq1 is HashSet<object> set
                ? new HashSet<object>(set, set.Comparer)
                : seq1.ToHashSet();
        }
    }
}
