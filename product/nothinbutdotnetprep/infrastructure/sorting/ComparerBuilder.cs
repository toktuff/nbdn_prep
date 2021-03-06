﻿using System;
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
            var second_criteria = new PropertyComparer<T, PropertyType>(func, new ComparableComparer<PropertyType>());
            current_comparer = new ChainedComparer<T>(current_comparer, second_criteria);
            return this;
        }

        public ComparerBuilder<T> reverse()
        {
            current_comparer = new ReverseComparer<T>(current_comparer);
            return this;
        }
    }
}