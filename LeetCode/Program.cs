namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solver solver = new Solver();

            string[] st = ["flower", "flow", "flight"];

            var result = solver.LongestCommonPrefix(st);
        }
    }
}
