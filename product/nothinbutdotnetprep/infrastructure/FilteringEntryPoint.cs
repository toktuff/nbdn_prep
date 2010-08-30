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

        public NegatingFilterEntryPoint<ItemToFilter, PropertyType> not
        {
            get { return new NegatingFilterEntryPoint<ItemToFilter, PropertyType>(accessor, this); }
        }
    }
}