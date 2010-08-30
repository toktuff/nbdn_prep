using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.ranges;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.infrastructure
{
    public static class FilteringExtensions
    {
        public static Criteria<ItemToFilter> equal_to<ItemToFilter, PropertyType>(this FilteringEntryPoint<ItemToFilter, PropertyType> entry_point, PropertyType value) 
        {
            return equal_to_any(entry_point, value);
        }

        public static Criteria<ItemToFilter> equal_to_any<ItemToFilter, PropertyType>(this FilteringEntryPoint<ItemToFilter, PropertyType> entry_point, params PropertyType[] values) 
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(entry_point.accessor, new IsEqualToAny<PropertyType>(values));
        }

        public static Criteria<ItemToFilter> falls_in<ItemToFilter,PropertyType>(this FilteringEntryPoint<ItemToFilter,PropertyType> entry_point,Range<PropertyType> value) where PropertyType: IComparable<PropertyType>, IComparer<PropertyType>
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(entry_point.accessor, new FallsInRange<PropertyType>(value));
        }
        public static Criteria<ItemToFilter> greater_than<ItemToFilter,PropertyType>(this FilteringEntryPoint<ItemToFilter,PropertyType> entry_point,PropertyType value) where PropertyType: IComparable<PropertyType>
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(entry_point.accessor, new IsGreaterThan<PropertyType>(value));
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