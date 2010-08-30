using System;

namespace nothinbutdotnetprep.infrastructure
{

    public class foo<ItemToFilter, PropertyType>
    {
        private Func<ItemToFilter, PropertyType> property_accessor;

        public foo(Func<ItemToFilter, PropertyType> func)
        {
            property_accessor = func;
        }

        public Criteria<ItemToFilter> equal_to<PropertyType>(PropertyType value_to_equal)
        {
            return new AnonymousCriteria<ItemToFilter>(item => property_accessor(item).Equals(value_to_equal));
        }

    }

    public static class Where<ItemToFilter>
    {
        public static foo<ItemToFilter, PropertyType> has_a<PropertyType>(Func<ItemToFilter, PropertyType> property_accessor)
        {
            return new foo<ItemToFilter, PropertyType>(property_accessor);
        }
    }
}