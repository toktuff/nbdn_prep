using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetprep.infrastructure
{
    public class NegatingFilterEntryPoint<ItemToFilter, PropertyType>
    {
        public NegatingFilterEntryPoint(Func<ItemToFilter, PropertyType> accessor, FilteringEntryPoint<ItemToFilter, PropertyType> filteringEntryPoint)
        {
            this.accessor = accessor;
            this.filteringEntryPoint = filteringEntryPoint;
        }

        public Func<ItemToFilter, PropertyType> accessor { get; private set; }
        public FilteringEntryPoint<ItemToFilter, PropertyType> filteringEntryPoint;
    }
}
