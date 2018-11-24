using System.Text;

namespace TPR4
{
    public static class StringExtensions
    {
        public static string DoIndex(this string name, int to, int from = 1)
        {
            var sb = new StringBuilder();
            for (int i = from; i <= to; i++)
                sb.Append($"{name}{i}, ");
            return sb.ToString();
        }
    }
}