using LeetCode.Models;

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

        #region Roman To Int

        // Tric: bir semboldan sonra gelen sembol eğer kendinden küçükse onu değer, kadar küçültür.
        // Ör IV -> 5-1 = 4 /  IX -> 10-1 = 9
        public int RomanToInt(string s)
        {
            Dictionary<char, int> romanMap = new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

            int sum = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (i + 1 < s.Length && romanMap[s[i]] < romanMap[s[i + 1]])
                {
                    sum -= romanMap[s[i]];
                }
                else
                {
                    sum += romanMap[s[i]];
                }
            }
            return sum;
        }

        #endregion

        #region Longest Common Prefix
        public string LongestCommonPrefix(string[] strs)
        {
            string prefix = strs[0];

            for (int i = 0; i < strs.Length; i++)
            {
                string currentPrefix = string.Empty;

                for (int j = 0; j < strs[i].Length; j++)
                {
                    if (j >= prefix.Length) break;

                    if (strs[i][j] == prefix[j])
                    {
                        currentPrefix += strs[i][j];
                    }
                    else
                    {
                        break;
                    }
                }

                prefix = currentPrefix;
            }

            return prefix;
        }

        #endregion

        #region Valid Parentheses

        /*         
            string param = "([)]";
            string param = "(){}}{";
            string param = "([])";
         */
        public bool IsValid(string s)
        {
            Dictionary<char, char> parentMap = new Dictionary<char, char>()
            {
                {'(',')' },
                {'{','}' },
                {'[',']' }
            };

            Stack<char> stack = new Stack<char>(); // stackte her zaman açılış parantezleri olacak

            for (int i = 0; i < s.Length; i++)
            {
                char current = s[i];

                if (parentMap.ContainsKey(current)) // ilgili char açılış parantezi mi ?
                {
                    stack.Push(current);
                }
                else if (parentMap.ContainsValue(current)) // ilgili char kapanış parantezi mi ?
                {
                    // stack'e eklenen son açılış parantezinin mapteki valuesu, cureent olmak zorunda çünkü sıralı işlem bekleniyor !
                    if (stack.Count == 0 || parentMap[stack.Peek()] != current)
                        return false;

                    stack.Pop();
                }
            }

            return stack.Count == 0;
        }

        #endregion

        #region Merge Two Sorted Lists

        public ListNode? MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(-1);
            ListNode current = dummy;


            while (l1 is not null && l2 is not null)
            {
                if (l1.val <= l2.val)
                {
                    current.next = l1;
                    l1 = l1.next!;
                }
                else
                {
                    current.next = l2;
                    l2 = l2.next!;
                }
                current = current.next;
            }

            current.next = l1 ?? l2;

            // dummy'nin next'i ilgili listenin hedaer'ı.
            return dummy.next;
        }

        #endregion

        #region Remove Duplicates from Sorted Array
        // int[] nums = [0, 0, 1, 1, 1, 2, 2, 3, 3, 4];

        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;

            int y = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[y])
                {
                    y++;
                    nums[y] = nums[i];
                }
            }

            return y + 1;
        }
        #endregion

        #region Remove Element

        //int val = 2;
        //int[] nums = [0, 1, 2, 2, 3, 0, 4, 2];

        public int RemoveElement(int[] nums, int val)
        {
            int y = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[y] = nums[i];
                }
            }

            return y;
        }

        #endregion

        #region Search Insert Position

        //int target = 2;
        //int[] nums = [1, 3, 5, 6];

        // varsa bulunduğu index'i yoksa olması gereken sıralı index'i
        public int SearchInsert(int[] nums, int target)
        {          
            for (int i = 0; i < nums.Length; i++)
            {
                if (target <= nums[i])
                    return i;
            }

            return nums.Length;
        }
        #endregion
    }
}
