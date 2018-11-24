using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TPR4
{
    public static class EnumerableExtensions
    {
        public static string ToLine<T>(this IEnumerable<T> source)
        {
            var sb = new StringBuilder();
            foreach (var e in source)
                sb.Append($"{e}, ");
            return sb.ToString();
        }
    }
}