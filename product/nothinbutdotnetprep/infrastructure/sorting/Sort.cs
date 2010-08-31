using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public static class Sort<ItemToSort> 
    {
        public static SortComparer<ItemToSort, PropertyType> by_ascending<PropertyType>(Func<ItemToSort, PropertyType> property_accessor) where PropertyType : IComparable<PropertyType>
        {
            return new SortComparer<ItemToSort,PropertyType>(true, property_accessor);
        }

        public static SortComparer<ItemToSort, PropertyType> by_descending<PropertyType>(Func<ItemToSort, PropertyType> property_accessor) where PropertyType : IComparable<PropertyType>
        {
            return new SortComparer<ItemToSort,PropertyType>(false, property_accessor);
        }        
    }

    public class SortComparer<ItemToSort, PropertyType> : IComparer<ItemToSort> where PropertyType : IComparable<PropertyType>
    {
        private readonly bool _ascendingOrder;
        private readonly Func<ItemToSort, PropertyType> _propertyAccessor;

        public SortComparer(bool ascendingOrder , Func<ItemToSort, PropertyType> propertyAccessor)
        {
            _ascendingOrder = ascendingOrder;
            _propertyAccessor = propertyAccessor;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            if (_ascendingOrder) 
                return _propertyAccessor(x).CompareTo(_propertyAccessor(y));
            return _propertyAccessor(y).CompareTo(_propertyAccessor(x));
            
        }
    }
}