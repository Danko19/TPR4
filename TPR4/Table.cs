using System.Text;

namespace TPR4
{
    public class Table
    {
        private const double Precision = 0.001;

        private readonly Matrix matrix;
        public Table(string fileName)
        {
            matrix = new Matrix(fileName);
        }

        public string Solve()
        {
            var sb = new StringBuilder();
            sb.AppendLine(GetHeader());
            var Bs = matrix.GetBStrategiesWithMinCost();
            var As = matrix.GetAStrategiesIfBIs(Bs.MinIndex);
            var previous = new TableLine(Bs, As);
            sb.AppendLine(previous.ToString());
            while (previous.V_max - previous.V_min > Precision)
            {
                Bs = matrix.GetBStrategiesIfAIs(previous.As.MaxIndex).Append(Bs);
                As = matrix.GetAStrategiesIfBIs(Bs.MinIndex).Append(As);
                previous = new TableLine(Bs, As);
                sb.AppendLine(previous.ToString());
            }

            return sb.ToString();
        }

        private string GetHeader()
        {
            return
                $"k, i, {"B".DoIndex(matrix.B_StrategiesCount)}j, {"A".DoIndex(matrix.A_StrategiesCount)}V_min, V_avg, V_max";
        }
    }
}