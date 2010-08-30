using System;

namespace nothinbutdotnetprep.infrastructure
{
    public class EqualToCriteria<T,TValue> : Criteria<T>
    {
        private readonly Func<T, TValue> _selector;
        private readonly TValue _expectedValue;

        public EqualToCriteria(Func<T, TValue> selector, TValue expectedValue)
        {
            _selector = selector;
            _expectedValue = expectedValue;
        }

        public bool is_satisfied_by(T item)
        {
            return _selector(item).Equals(_expectedValue);
        }
    }
}