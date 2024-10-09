using LeetCode.Models;

namespace LeetCode
{
    internal class Program
    {
        static void Main()
        {
            Solver s = new();


            //string haystack = "mississippi";

            //string needle = "pi";

            string haystack = "leetcode";

            string needle = "leeto";

            int res = s.StrStr(haystack, needle);
        }
    }
}
