using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.infrastructure
{
    public class IsEqualToAny<T> : Criteria<T>
    {
        IList<T> values;

        public IsEqualToAny(params T[] values)
        {
            this.values = new List<T>(values);
        }

        public bool is_satisfied_by(T item)
        {
            return values.Contains(item);
        }
    }
}