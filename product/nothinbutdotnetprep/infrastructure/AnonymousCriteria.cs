using System;

namespace nothinbutdotnetprep.infrastructure
{

    public class AnonymousCriteria<T> : Criteria<T>
    {
        Predicate<T> criteria;

        public AnonymousCriteria(Predicate<T> criteria)
        {
            this.criteria = criteria;
        }

        public bool is_satisfied_by(T item)
        {
            return criteria(item);
        }
    }
}