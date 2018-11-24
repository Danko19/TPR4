using System;
using System.Linq;
using System.Text;

namespace TPR4
{
    public class Table
    {
        private const double Precision = 0.001;

        private readonly Matrix matrix;
        private readonly int[] AChoises;
        private readonly int[] BChoises;

        private TableLine last;

        public Table(string fileName)
        {
            matrix = new Matrix(fileName);
            AChoises = new int[matrix.A_StrategiesCount];
            BChoises = new int[matrix.B_StrategiesCount];
        }

        public string Solve()
        {
            var sb = new StringBuilder();
            sb.AppendLine(GetHeader());
            var Bs = matrix.GetBStrategiesWithMinCost();
            var As = matrix.GetAStrategiesIfBIs(Bs.MinIndex);
            IncrementStats(Bs, As);
            last = new TableLine(Bs, As);
            sb.AppendLine(last.ToString());
            while (last.V_max - last.V_min > Precision)
            {
                Bs = matrix.GetBStrategiesIfAIs(last.As.MaxIndex).Append(Bs);
                As = matrix.GetAStrategiesIfBIs(Bs.MinIndex).Append(As);
                IncrementStats(Bs, As);
                last = new TableLine(Bs, As);
                sb.AppendLine(last.ToString());
            }

            sb.AppendLine(GetAnswer());
            return sb.ToString();
        }

        private string GetHeader()
        {
            return
                $"k, i, {"B".DoIndex(matrix.B_StrategiesCount)}j, {"A".DoIndex(matrix.A_StrategiesCount)}V_min, V_avg, V_max";
        }

        private string GetAnswer()
        {
            return
                $", S_b, {"p_b".DoIndex(matrix.B_StrategiesCount)}S_a, {"p_a".DoIndex(matrix.A_StrategiesCount)},Game cost, " + Environment.NewLine
                    + $",,{BChoises.Select(x => ((double) x / count).Format()).ToLine()},{AChoises.Select(x => ((double)x / count).Format()).ToLine()},{last.V_avg.Format()}";
        }

        private void IncrementStats(Strategies Bs, Strategies As)
        {
            BChoises[Bs.Index]++;
            AChoises[As.Index]++;
        }

        private int count => last.Number;
    }
}