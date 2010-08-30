using System;

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
    }
}