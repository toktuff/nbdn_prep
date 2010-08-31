using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class PropertyComparer<ItemToSort, PropertyType> : IComparer<ItemToSort>
    {
        Func<ItemToSort, PropertyType> property_accessor;
        IComparer<PropertyType> real_comparer;

        public PropertyComparer(Func<ItemToSort, PropertyType> property_accessor, IComparer<PropertyType> real_comparer)
        {
            this.property_accessor = property_accessor;
            this.real_comparer = real_comparer;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return real_comparer.Compare(property_accessor(x), property_accessor(y));
        }
    }
}