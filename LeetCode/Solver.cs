namespace LeetCode
{
    public class Solver
    {
        #region Two Sum

        /*
          int[] nums = [2, 7, 11, 15];
          int target = 9;
         */

        public int[] TwoSumBruteForce(int[] nums, int target)
        {
            int[] result = new int[2];

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        result[0] = i;
                        result[1] = j;
                        break;
                    }
                }
            }
            return result;
        }

        public int[] TwoSumDictionary(int[] nums, int target)
        {
            Dictionary<int, int> numDict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                if (numDict.TryGetValue(complement, out int value))
                {
                    return new int[] { value, i };
                }

                numDict[nums[i]] = i;
            }

            return new int[0];
        }

        #endregion

        #region Palindrome Number

        public bool IsPalindrome(int x)
        {
            string numberSt = x.ToString();
            char[] stringArr = numberSt.ToCharArray();
            Array.Reverse(stringArr);

            string reversedString = new(stringArr);

            bool isSuccess = int.TryParse(reversedString, out int result);

            if (isSuccess)
                return x == result;
            else
                return false;
        }

        public bool IsPalindromeOptimized(int x)
        {
            if (x < 0) return false;

            int orjinal = x;
            int reversed = 0;

            while (x > 0)
            {
                int lastDijit = x % 10;
                reversed = reversed * 10 + lastDijit;
                x /= 10;
            }

            return orjinal == reversed;
        }

        #endregion
    }
}
