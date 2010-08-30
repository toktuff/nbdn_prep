using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure
{
    public static class FilteringExtensions
    {
        public static Criteria<ItemToFilter> equal_to<ItemToFilter, PropertyType>(
            this FilteringEntryPoint<ItemToFilter, PropertyType> entry_point, PropertyType value) 
        {
            return new AnonymousCriteria<ItemToFilter>(item => entry_point.accessor(item).Equals(value));
        }

        public static Criteria<ItemToFilter> equal_to_any<ItemToFilter, PropertyType>(
            this FilteringEntryPoint<ItemToFilter, PropertyType> entry_point, params PropertyType[] values) 
        {
            return
                new AnonymousCriteria<ItemToFilter>(
                    filter => new List<PropertyType>(values).Contains(entry_point.accessor(filter)));
        }

        public static Criteria<ItemToFilter> not_equal_to<ItemToFilter,PropertyType>(this FilteringEntryPoint<ItemToFilter,PropertyType> entry_point,PropertyType value_to_equal)
        {
            return new NotCriteria<ItemToFilter>(equal_to(entry_point, value_to_equal));
        }


        public static Criteria<ItemToFilter> greater_than<ItemToFilter,PropertyType>(this FilteringEntryPoint<ItemToFilter,PropertyType> entry_point,PropertyType value) where PropertyType: IComparable<PropertyType>
        {
            return new AnonymousCriteria<ItemToFilter>(filter => entry_point.accessor(filter).CompareTo(value) > 0);
        }

        public static Criteria<ItemToFilter> less_than<ItemToFilter,PropertyType>(this FilteringEntryPoint<ItemToFilter,PropertyType> entry_point,PropertyType value) where PropertyType : IComparable<PropertyType>
        {
            return new AnonymousCriteria<ItemToFilter>(filter => entry_point.accessor(filter).CompareTo(value) < 0);
        }
        public static Criteria<ItemToFilter> between<ItemToFilter,PropertyType>(this FilteringEntryPoint<ItemToFilter,PropertyType> entry_point,PropertyType lowerValue, PropertyType upperValue) where PropertyType : IComparable<PropertyType>
        {
            return (greater_than(entry_point,lowerValue).and(less_than(entry_point,upperValue)))
                .or(equal_to(entry_point, lowerValue)).or(equal_to(entry_point, upperValue));
        }
    }
}