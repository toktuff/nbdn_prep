using System;

namespace nothinbutdotnetprep.infrastructure
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter,PropertyType> where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;
        CriteriaFactory<ItemToFilter, PropertyType> basic_factory;

        public ComparableCriteriaFactory(Func<ItemToFilter, PropertyType> accessor):this(accessor, new DefaultCriteriaFactory<ItemToFilter, PropertyType>(accessor))
        {
        }

        public ComparableCriteriaFactory(Func<ItemToFilter, PropertyType> property_accessor,CriteriaFactory<ItemToFilter,PropertyType> basic_factory)
        {
            this.accessor = property_accessor;
            this.basic_factory = basic_factory;
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
            return basic_factory.equal_to(value_to_equal);
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value_to_equal)
        {
            return basic_factory.not_equal_to(value_to_equal);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return basic_factory.equal_to_any(values);
        }

        public Criteria<ItemToFilter> between(PropertyType lowerValue, PropertyType upperValue)
        {
            return (greater_than(lowerValue).and(less_than(upperValue)))
                .or(equal_to(lowerValue)).or(equal_to(upperValue));
        }
    }
}