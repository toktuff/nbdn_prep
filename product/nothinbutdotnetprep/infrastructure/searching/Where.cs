using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public static class Where<ItemToFilter>
    {
        public static FilteringEntryPoint<ItemToFilter, PropertyType> has_a<PropertyType>(Func<ItemToFilter, PropertyType> property_accessor)
        {
            return new FilteringEntryPoint<ItemToFilter, PropertyType>(property_accessor);
        }
    }
}