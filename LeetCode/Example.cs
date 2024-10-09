using LeetCode.Models;

namespace LeetCode
{
    public class Example
    {
        #region LinkedList

        public void ListNodeExample()
        {
            ListNode nodeA1 = new ListNode(1); // header
            ListNode nodeA2 = new ListNode(2);
            nodeA1.next = nodeA2;

            ListNode nodeA3 = new ListNode(4);
            nodeA2.next = nodeA3;

            ListNode nodeB1 = new ListNode(1); // header
            ListNode nodeB2 = new ListNode(3);
            nodeB1.next = nodeB2;

            ListNode nodeB3 = new ListNode(4);
            nodeB2.next = nodeB3;

            ShowListNode(nodeA1, "input-1");
            ShowListNode(nodeB1, "input-2");
        }

        private void ShowListNode(ListNode? node, string header = "header")
        {
            Console.Write($"{header}: ");
            while (node is not null)
            {
                Console.Write($"{node.val.ToString()} -> ");
                node = node.next;
            }
            Console.WriteLine("NULL");
        }

        #endregion


    }
}
