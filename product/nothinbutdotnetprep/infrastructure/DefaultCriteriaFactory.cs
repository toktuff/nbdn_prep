using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure
{
    public class DefaultCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        Func<ItemToFilter, PropertyType> property_accessor;

        public DefaultCriteriaFactory(Func<ItemToFilter, PropertyType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value_to_equal)
        {
            return new AnonymousCriteria<ItemToFilter>(item => property_accessor(item).Equals(value_to_equal));
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType value_to_equal)
        {
            return new NotCriteria<ItemToFilter>(equal_to(value_to_equal));
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return
                new AnonymousCriteria<ItemToFilter>(
                    filter => new List<PropertyType>(values).Contains(property_accessor(filter)));
        }

    }
}