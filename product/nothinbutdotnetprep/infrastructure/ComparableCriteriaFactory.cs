using System;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.infrastructure
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;

        public ComparableCriteriaFactory(Func<ItemToFilter, PropertyType> property_accessor)
        {
            this.accessor = property_accessor;
        }

        public Criteria<ItemToFilter> greater_than(PropertyType value)
        {
            return new AnonymousCriteria<ItemToFilter>(filter => accessor(filter).CompareTo(value) > 0);
        }

        public Criteria<ItemToFilter> less_than(PropertyType value)
        {
            return new AnonymousCriteria<ItemToFilter>(filter => accessor(filter).CompareTo(value) < 0);
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return new AnonymousCriteria<ItemToFilter>(item => accessor(item).Equals(value_to_equal));
        }

        public Criteria<ItemToFilter> between(PropertyType lowerValue, PropertyType upperValue)
        {
            return (greater_than(lowerValue).and(less_than(upperValue)))
                .or(equal_to(lowerValue)).or(equal_to(upperValue));
        }
    }
}