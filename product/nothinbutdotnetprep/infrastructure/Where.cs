using System;

namespace nothinbutdotnetprep.infrastructure
{
    public static class Where<ItemToFilter>
    {
        public static DefaultCriteriaFactory<ItemToFilter, PropertyType> has_a<PropertyType>(Func<ItemToFilter, PropertyType> property_accessor)
        {
            return new DefaultCriteriaFactory<ItemToFilter, PropertyType>(property_accessor);
        }

        public static ComparableCriteriaFactory<ItemToFilter,PropertyType> has_an<PropertyType>(Func<ItemToFilter, PropertyType> property_accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparableCriteriaFactory<ItemToFilter, PropertyType>(property_accessor);
        }
    }
}