using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TPR4
{
    public class Matrix
    {
        private readonly List<int[]> data = new List<int[]>();

        public Matrix(string fileName)
        {
            Parse(fileName);
        }

        public int A_StrategiesCount => data.Count;
        public int B_StrategiesCount => data.Any() ? data.First().Length : 0;

        public Strategies GetAStrategiesIfBIs(int bIndex)
        {
            var array = new int[A_StrategiesCount];
            for (int i = 0; i < A_StrategiesCount; i++)
                array[i] = data[i][bIndex];
            return new Strategies(array, bIndex);
        }

        public Strategies GetBStrategiesIfAIs(int aNumber)
        {
            var array = new int[B_StrategiesCount];
            data[aNumber].CopyTo(array, 0);
            return new Strategies(array, aNumber);
        }

        public Strategies GetBStrategiesWithMinCost()
        {
            var min = int.MaxValue;
            var index = -1;
            for (int i = 0; i < data.Count; i++)
            {
                var localMin = data[i].Min();
                if (localMin < min)
                {
                    min = localMin;
                    index = i;
                }
            }

            return GetBStrategiesIfAIs(index);
        }

        private void Parse(string fileName)
        {
            var previous = -1;
            foreach (var line in File.ReadLines(fileName))
            {
                var split = line.Replace(" ", "").Split(',');
                if (split.Length != previous && previous != -1)
                    throw new ArgumentException("Invalid input matrix size");
                previous = split.Length;
                data.Add(split.Select(int.Parse).ToArray());
            }
        }
    }
}