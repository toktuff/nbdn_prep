using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class ComparerBuilder<T> : IComparer<T>
    {
        IComparer<T> current_comparer;

        public ComparerBuilder(IComparer<T> currentComparer)
        {
            this.current_comparer = currentComparer;
        }

        public int Compare(T x, T y)
        {
            return current_comparer.Compare(x, y);
        }

        public ComparerBuilder<T> then_by<PropertyType>(Func<T, PropertyType> func) where PropertyType : IComparable<PropertyType>
        {
            var result = new ChainedComparer<T>(this.current_comparer,
                                                new PropertyComparer<T, PropertyType>(func,
                                                                                      new ComparableComparer
                                                                                          <PropertyType>()));
            this.current_comparer = result;
            return this;
        }
    }
}