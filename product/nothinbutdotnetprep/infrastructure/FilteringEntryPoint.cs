using System;

namespace nothinbutdotnetprep.infrastructure
{
    public class FilteringEntryPoint<ItemToFilter,PropertyType>
    {
        public FilteringEntryPoint(Func<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Func<ItemToFilter, PropertyType> accessor { get; private set; }
    }
}