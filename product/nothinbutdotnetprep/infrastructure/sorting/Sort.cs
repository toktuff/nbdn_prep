using System;
using System.Collections.Generic;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public static class Sort<ItemToSort> 
    {
        public static ComparerBuilder<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> property_accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(
                new PropertyComparer<ItemToSort, PropertyType>(property_accessor, new ComparableComparer<PropertyType>()));
        }
        
        public static ComparerBuilder<ItemToSort> by_descending<PropertyType>(Func<ItemToSort, PropertyType> property_accessor) where PropertyType : IComparable<PropertyType>
        {
            return by(property_accessor).reverse();
        }

        public static ComparerBuilder<ItemToSort> by_ranking<PropertyType>(Func<ItemToSort, PropertyType> property_accessor, params PropertyType[] ranking)
        {

            var raw_comparer = new RankingComparer<PropertyType>(ranking);

            return new ComparerBuilder<ItemToSort>(
                new PropertyComparer<ItemToSort, PropertyType>(property_accessor,
                                                               raw_comparer));
        }

    }
}