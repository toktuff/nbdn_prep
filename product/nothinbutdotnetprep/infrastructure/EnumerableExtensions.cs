using System.Collections.Generic;
using nothinbutdotnetprep.collections;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.infrastructure
{
    public static class EnumerableExtensions
    {
        static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items,
                                                           ExplicitCriteria<T> explicit_criteria)
        {
            foreach (var item in items)
            {
                if (explicit_criteria(item))
                    yield return item;
            }
        }

        public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, Criteria<T> criteria)
        {
            return items.all_items_matching(criteria.is_satisfied_by);
        }

        public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
        {
            foreach (var item in items) yield return item;
        }

        public static IEnumerable<T> sort_using<T>(this IEnumerable<T> items_to_sort, IComparer<T> comparer)
        {
            List<T> listToSort = new List<T>(items_to_sort);
            listToSort.Sort(comparer);
            return ((IList<T>)listToSort).one_at_a_time();
        }
    }
}