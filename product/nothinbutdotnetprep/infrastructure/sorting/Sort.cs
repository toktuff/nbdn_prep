using System;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public static class Sort<ItemToSort> 
    {
        public static PropertyComparer<ItemToSort, PropertyType> by<PropertyType>(Func<ItemToSort, PropertyType> property_accessor,SortDirection direction) where PropertyType : IComparable<PropertyType>
        {
            return new PropertyComparer<ItemToSort,PropertyType>(property_accessor,
                direction.apply_against(new ComparableComparer<PropertyType>()));
        }
        public static PropertyComparer<ItemToSort, PropertyType> by_ascending<PropertyType>(Func<ItemToSort, PropertyType> property_accessor) where PropertyType : IComparable<PropertyType>
        {
            return new PropertyComparer<ItemToSort,PropertyType>(true, property_accessor);
        }

        public static PropertyComparer<ItemToSort, PropertyType> by_descending<PropertyType>(Func<ItemToSort, PropertyType> property_accessor) where PropertyType : IComparable<PropertyType>
        {
            return new PropertyComparer<ItemToSort,PropertyType>(property_accessor,
                new ReverseComparer<PropertyType>(new ComparableComparer<PropertyType>()));
        }        
    }
}