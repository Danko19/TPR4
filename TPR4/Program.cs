using System.IO;

namespace TPR4
{
    class Program
    {
        static void Main(string[] args)
        {
            //var fileName = args[0];
            var fileName = "example.txt";
            var table = new Table(fileName);
            File.WriteAllText($"solve_{fileName}", table.Solve());
        }
    }
}
