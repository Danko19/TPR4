using System.Globalization;

namespace TPR4
{
    public class TableLine
    {
        private static int totalNumber = 1;

        public readonly int Number;
        public readonly Strategies As;
        public readonly Strategies Bs;

        public double V_min => (double) Bs.Min / Number;
        public double V_max => (double) As.Max / Number;

        public double v_avg => (V_max + V_min) / 2;
        public int I => Bs.Index;
        public int J => As.Index;

        public TableLine(Strategies Bs, Strategies As)
        {
            Number = totalNumber++;
            this.As = As;
            this.Bs = Bs;
        }

        public override string ToString()
        {
            return $"{Number}, {I}, {Bs}{J}, {As}{V_min.ToString(NumberFormatInfo.InvariantInfo)}, {v_avg.ToString(NumberFormatInfo.InvariantInfo)}, {V_max.ToString(NumberFormatInfo.InvariantInfo)}";
        }
    }
}