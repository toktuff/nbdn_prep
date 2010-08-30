using System;

namespace nothinbutdotnetprep.infrastructure
{
    public class CriteriaFactory<ItemToFilter, PropertyType>
    {
        Func<ItemToFilter, PropertyType> property_accessor;

        public CriteriaFactory(Func<ItemToFilter, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public Criteria<ItemToFilter> equal_to<PropertyType>(PropertyType value_to_equal)
        {
            return new AnonymousCriteria<ItemToFilter>(item => property_accessor(item).Equals(value_to_equal));
        }

    }
}