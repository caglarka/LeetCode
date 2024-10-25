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

        #region Find the Index of the First Occurrence in a String

        //string haystack = "mississippi";
        //string needle = "pi";

        //string haystack = "leetcode";
        //string needle = "leeto";

        public int StrStr(string haystack, string needle)
        {
            if (haystack.Length < needle.Length) return -1;

            int y = 0;
            int startIndex = -1;

            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] == needle[y])
                {
                    if (y == 0)
                        startIndex = i;

                    if (y + 1 == needle.Length)
                        return startIndex;

                    y++;
                }
                else if (startIndex != -1)
                {
                    i = startIndex;
                    y = 0;
                    startIndex = -1;
                }
            }

            return -1;
        }
        #endregion

        #region Length of Last Word

        //string p = "Hello World";
        //string p1 = "   fly me   to   the moon  ";

        public int LengthOfLastWord(string s)
        {
            int c = 0;
            int y = 1; // doludan boşa dönerken değer değişiyor.

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ' && y == 1)
                {
                    c++;
                }
                else if (s[i] == ' ' && y == 1)
                {
                    y = 0;
                }
                else if (s[i] != ' ' && y == 0)
                {
                    c = 1;
                    y = 1;
                }
            }

            return c;
        }

        #endregion

        #region Plus One

        //int[] d = [6, 1, 4, 5, 3, 9, 0, 1, 9, 5, 1, 8, 6, 7, 0, 5, 5, 4, 3];
        int[] d = [1, 2, 9];

        public int[] PlusOneV1(int[] digits)
        {
            int[] res;

            if (digits[^1] == 9)
                res = new int[digits.Length + 1];
            else
                res = new int[digits.Length];

            int v = 0;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (i == digits.Length - 1)
                {
                    int sum = digits[i] + 1;

                    if (sum == 10)
                    {
                        res[i] = 0;
                        v = 1;
                    }
                    else
                        res[i] = sum;
                }
                else if (digits[i] + v == 10)
                {
                    res[i] = 0;
                    v = 1;
                }
                else
                    res[i] = digits[i];
            }

            if (res.Length == 2 && v == 1)
                res[0] = v;

            return res;
        }


        public int[] PlusOne(int[] d)
        {

            for (int i = d.Length - 1; i >= 0; i--)
            {
                if (d[i] != 9) // son basamak 9 değil ise, 1 ekle ve diziyi dön.
                {
                    d[i]++;
                    return d;
                }
                // Eğer basamak 9 ise , i. basamağı 0 yap
                d[i] = 0;
            }

            int[] res = new int[d.Length + 1];
            res[0] = 1;  // İlk elemanı 1 yap, geri kalanlar zaten 0
            return res;
        }
        #endregion

        #region Add Binary
        public string AddBinary(string a, string b)
        {
            int al = a.Length;
            int bl = b.Length;

            int carry = 0;
            string res = "";

            while (al >= 0 || bl >= 0 || carry > 0)
            {
                int aV = al >= 0 ? a[al] - '0' : 0;
                int bV = bl >= 0 ? b[bl] - '0' : 0;

                int sum = aV + bV + carry;
                carry = sum / 2;
                res = (sum % 2).ToString() + res;

                al--;
                bl--;
            }

            return res;
        }

        #endregion

        #region Sqrt(x)
        public int MySqrt(int x)
        {
            if (x == 0 || x == 1)
                return x;

            int left = 1;
            int right = x;
            int result = 0;

            while (left <= right)
            {
                int mid = left + (right - left) / 2; // orta değerini bul. 1 ile x'in oratı middir. binary search orta bulma yontemi
                // left + (right - left) / 2 formülünü kullanıyoruz. Bunun sebebi, büyük sayılarla çalışırken taşma (overflow) riskini azaltmaktır.

                long square = (long)mid * mid; // orta değerinin karesini al

                if (square == x) // square == parametreye ? ok ise dön
                {
                    return mid;
                }
                else if (square < x) // parametrenin yarısının karesi kendisinden kücükse, yarı değerine 1 ekle
                {
                    left = mid + 1;
                    result = mid;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return result;
        }
        #endregion

        #region Climbing Stairs        

        public int ClimbStairs(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;

            int a = 1;
            int b = 2;

            for (int i = 3; i <= n; i++)
            {
                int c = a + b;

                a = b;
                b = c;
            }

            return b;
        }
        #endregion

        #region Remove Duplicates from Sorted List
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
                return null;

            Dictionary<int, bool> dic = new();

            ListNode beforeNode = null;
            ListNode currentNode = head;

            while (currentNode != null)
            {
                if (dic.ContainsKey(currentNode.val))
                    beforeNode.next = currentNode.next;
                else
                {
                    dic.Add(currentNode.val, true);
                    beforeNode = currentNode;
                }

                currentNode = currentNode.next;
            }

            return head;
        }
        #endregion

        #region Merge Sorted Array
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1;      // 2
            int j = n - 1;      // 2
            int k = m + n - 1;  // 5

            while (i >= 0 && j >= 0)
            {
                if (nums1[i] > nums2[j])
                {
                    nums1[k] = nums1[i];
                    i--;
                }
                else
                {
                    nums1[k] = nums2[j];
                    j--;
                }
                k--;
            }

            while (j >= 0)
            {
                nums1[k] = nums2[j];
                j--;
                k--;
            }
        }
        #endregion
    }
}
