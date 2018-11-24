using System;
using System.Text;

namespace TPR4
{
    public class Strategies
    {
        private readonly int[] data;

        public Strategies(int[] data, int index)
        {
            this.data = data;
            Index = index;
            Search();
        }

        public int Index { get; }
        public int Max { get; private set; }
        public int MaxIndex { get; private set; }
        public int Min { get; private set; }
        public int MinIndex { get; private set; }

        public Strategies Append(Strategies olStrategies)
        {
            if (data.Length != olStrategies.data.Length)
                throw new ArgumentException("Cannot sum Strategies with different lengths");
            var sum = new int[data.Length];
            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] = data[i] + olStrategies.data[i];
            }
       
            return new Strategies(sum, Index);
        }

        private void Search()
        {
            var max = int.MinValue;
            var maxIndex = -1;
            var min = int.MaxValue;
            var minIndex = -1;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] > max)
                {
                    max = data[i];
                    maxIndex = i;
                }
                if (data[i] < min)
                {
                    min = data[i];
                    minIndex = i;
                }
            }

            Max = max;
            MaxIndex = maxIndex;
            Min = min;
            MinIndex = minIndex;
        }

        public override string ToString()
        {
            return data.ToLine();
        }
    }
}