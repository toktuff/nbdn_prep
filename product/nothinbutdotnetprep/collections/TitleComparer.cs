using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class TitleComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.title.CompareTo(y.title);
        }
    }
}