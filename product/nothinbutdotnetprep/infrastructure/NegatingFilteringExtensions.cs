using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.ranges;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.infrastructure
{
    public static class NegatingFilteringExtensions
    {
        public static Criteria<ItemToFilter> equal_to<ItemToFilter, PropertyType>(this NegatingFilterEntryPoint<ItemToFilter, PropertyType> entry_point, PropertyType value) 
        {
            return equal_to_any(entry_point, value);
        }

        public static Criteria<ItemToFilter> equal_to_any<ItemToFilter, PropertyType>(this NegatingFilterEntryPoint<ItemToFilter, PropertyType> entry_point, params PropertyType[] values)
        {
            return new NotCriteria<ItemToFilter>(entry_point.filteringEntryPoint.equal_to_any(values));
        }

        public static Criteria<ItemToFilter> falls_in<ItemToFilter,PropertyType>(this NegatingFilterEntryPoint<ItemToFilter,PropertyType> entry_point,Range<PropertyType> value) where PropertyType: IComparable<PropertyType>, IComparer<PropertyType>
        {
            return new NotCriteria<ItemToFilter>(entry_point.filteringEntryPoint.falls_in(value));
        }
        public static Criteria<ItemToFilter> greater_than<ItemToFilter,PropertyType>(this NegatingFilterEntryPoint<ItemToFilter,PropertyType> entry_point,PropertyType value) where PropertyType: IComparable<PropertyType>
        {
            return new NotCriteria<ItemToFilter>(entry_point.filteringEntryPoint.greater_than(value));
        }

        public static Criteria<ItemToFilter> less_than<ItemToFilter,PropertyType>(this NegatingFilterEntryPoint<ItemToFilter,PropertyType> entry_point,PropertyType value) where PropertyType : IComparable<PropertyType>
        {
            return new NotCriteria<ItemToFilter>(entry_point.filteringEntryPoint.less_than(value));
        }
        public static Criteria<ItemToFilter> between<ItemToFilter,PropertyType>(this NegatingFilterEntryPoint<ItemToFilter,PropertyType> entry_point,PropertyType lowerValue, PropertyType upperValue) where PropertyType : IComparable<PropertyType>
        {
            return new NotCriteria<ItemToFilter>(entry_point.filteringEntryPoint.between(lowerValue, upperValue));
        }
    }
}