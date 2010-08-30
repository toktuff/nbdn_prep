using System;

namespace nothinbutdotnetprep.infrastructure
{
    public static class FilteringExtensions
    {
        public static Criteria<ItemToFilter> equal_to<ItemToFilter, PropertyType>(
            this FilteringEntryPoint<ItemToFilter, PropertyType> entry_point, PropertyType value) 
        {
            return new AnonymousCriteria<ItemToFilter>(item => entry_point.accessor(item).Equals(value));
        }

        public static Criteria<ItemToFilter> greater_than<ItemToFilter, PropertyType>(
            this FilteringEntryPoint<ItemToFilter, PropertyType> entry_point, PropertyType value) where PropertyType : IComparable<PropertyType>
        {
            return new AnonymousCriteria<ItemToFilter>(filter => entry_point.accessor(filter).CompareTo(value) > 0);
        }
    }
}