namespace nothinbutdotnetprep.infrastructure
{
    public class NegatingFilterEntryPoint<ItemToFilter, PropertyType>
    {
        public NegatingFilterEntryPoint(FilteringEntryPoint<ItemToFilter, PropertyType> filteringEntryPoint)
        {
            this.filtering_entry_point = filteringEntryPoint;
        }

        public FilteringEntryPoint<ItemToFilter, PropertyType> filtering_entry_point;
    }
}