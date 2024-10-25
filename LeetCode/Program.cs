using LeetCode.Models;

namespace LeetCode
{
    internal class Program
    {
        static void Main()
        {
            Solver s = new();


            int[] nums1 = [1, 2, 3, 0, 0, 0];
            int m = 3;
            int[] nums2 = [2, 5, 6];
            int n = 3;

            s.Merge(nums1, m, nums2, n);
            

        }
    }
}
