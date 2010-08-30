using System;

namespace nothinbutdotnetprep.infrastructure
{
    public static class Where<ItemToFilter>
    {
        public static Func<ItemToFilter, PropertyType> has_a<PropertyType>(Func<ItemToFilter, PropertyType> property_accessor)
        {
            return property_accessor;
        }
    }

    public static class FuncExtensions
    {
        public static Criteria<ItemToFilter> equal_to<ItemToFilter, PropertyType>(this Func<ItemToFilter, PropertyType> property_accessor, PropertyType value_to_equal)
        {
            return new AnonymousCriteria<ItemToFilter>(item => property_accessor(item).Equals(value_to_equal));
        }
    }
}