using System;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.infrastructure
{
    public static class Where<T>
    {
        public static Func<T, TResult> has_a<TResult>(Func<T, TResult> methodToInvoke)
        {
            return methodToInvoke;
        }
    }

    public static class FuncExtensions
    {
        public static Criteria<T> equal_to<T,TResult>(this Func<T,TResult> func, TResult value)
        {
            return new EqualToCriteria<T, TResult>(func, value);
        }
    }
}