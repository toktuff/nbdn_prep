using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class RankingComparer<T> : IComparer<T>
    {
        Dictionary<T, int> _rankings;

        public RankingComparer(T[] ranking)
        {
            this._rankings = new Dictionary<T, int>();
            for (int i = 0; i < ranking.Length; i++)
            {
                _rankings.Add(ranking[i], i);
            }
        }

        public int Compare(T x, T y)
        {
            return _rankings[x].CompareTo(_rankings[y]);
        }
    }
}