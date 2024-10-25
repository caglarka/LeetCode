using LeetCode.Models;

namespace LeetCode
{
    public class Example
    {
        #region LinkedList

        public void ListNodeExample()
        {
            ListNode head = new ListNode(1); // header
            ListNode nodeA2 = new ListNode(2);
            ListNode nodeA3 = new ListNode(3);
            ListNode nodeA4 = new ListNode(4);
            ListNode nodeA5 = new ListNode(5);

            head.next = nodeA2;
            nodeA2.next = nodeA3;
            nodeA3.next = nodeA4;
            nodeA4.next = nodeA5;

            ShowListNode(head, "input-1");

            DeleteNodeWithIndex(head, 3);

            ShowListNode(head, "d-input-1");
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

        private void DeleteNodeWithIndex(ListNode head, int index)
        {
            if (head is null)
                return;

            if (index == 0)
            {
                head = head.next;
            }

            ListNode? current = head;
            // verilen index'in bir öncesine kadar listde gidilir.
            for (int i = 0; i < index - 1; i++)
            {
                if (current?.next == null)
                {
                    return;
                }

                current = current.next;// sonraki node
            }

            if (current?.next != null)
            {
                current.next = current.next.next;
            }
        }
        #endregion


    }
}
