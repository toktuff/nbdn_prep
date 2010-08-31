namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class SortDirections
    {
        public static readonly SortDirection acsending = new NormalSortDirection();        
        public static readonly SortDirection descending = new ReverseSortDirection();        
    }
}