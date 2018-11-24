using System;
using System.Globalization;

namespace TPR4
{
    public static class DoubleExtensions
    {
        public static string Format(this double number, int decimals = 3)
        {
            return Math.Round(number, decimals).ToString(CultureInfo.InvariantCulture);
        }
    }
}