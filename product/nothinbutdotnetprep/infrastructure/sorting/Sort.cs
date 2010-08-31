using System;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public static class Sort<ItemToSort> 
    {
        public static ComparerBuilder<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> property_accessor,SortDirection direction) where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(
                new PropertyComparer<ItemToSort, PropertyType>(property_accessor,
                                                               direction.apply_against(
                                                                   new ComparableComparer<PropertyType>())));
        }
        public static ComparerBuilder<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> property_accessor, params PropertyType[] ranking)
        {

            var raw_comparer = new RankingComparer<PropertyType>(ranking);

            return new ComparerBuilder<ItemToSort>(
                new PropertyComparer<ItemToSort, PropertyType>(property_accessor,
                                                               raw_comparer));
        }
    }
}