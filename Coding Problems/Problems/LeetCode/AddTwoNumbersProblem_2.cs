using System.Text;

namespace Coding_Problems.Problems.LeetCode
{
    internal class AddTwoNumbersProblem_2 : IProblem, ILeetCodeProblem
    {
        public int Id { get; } = 2;
        public string Name { get; } = "Add Two Numbers Problem";
        public string Difficulty { get; } = "Medium";

        public void Solve()
        {
            // example 1
            // l1
            ListNode list1N3 = new(3);
            ListNode list1N2 = new(4, list1N3);
            ListNode list1N1 = new(2, list1N2);

            // l2
            ListNode list2N3 = new(4);
            ListNode list2N2 = new(6, list2N3);
            ListNode list2N1 = new(5, list2N2);

            Solve(1, list1N1, list2N1);

            // example 2
            // l1
            ListNode list3N1 = new(0);
            // l2
            ListNode list4N1 = new(0);

            Solve(2, list3N1, list4N1);

            // example 3
            // l1
            ListNode list5N7 = new(9);
            ListNode list5N6 = new(9, list5N7);
            ListNode list5N5 = new(9, list5N6);
            ListNode list5N4 = new(9, list5N5);
            ListNode list5N3 = new(9, list5N4);
            ListNode list5N2 = new(9, list5N3);
            ListNode list5N1 = new(9, list5N2);

            // l2
            ListNode list6N4 = new(9);
            ListNode list6N3 = new(9, list6N4);
            ListNode list6N2 = new(9, list6N3);
            ListNode list6N1 = new(9, list6N2);

            Solve(3, list5N1, list6N1);
        }

       private static void Solve(int exampleNum, ListNode l1, ListNode l2)
        {
            ListNode result = AddTwoNumbersSolution.AddTwoNumbers(l1, l2);

            Console.WriteLine($"Example {exampleNum}):");
            Console.WriteLine($"  Input: l1 = [{Utils.PrintNode(l1)}], l2 = [{Utils.PrintNode(l2)}]");
            Console.WriteLine($"  Output: [{Utils.PrintNode(result)}]");
            Console.WriteLine();
        }

    }

    internal class AddTwoNumbersSolution
    {
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int result = GetValue(l1) + GetValue(l2);
            return Utils.CreateListNode(result);
        }

        private static int GetValue(ListNode listNode)
        {
            string original = Utils.PrintNode(listNode, false);
            char[] chars = original.ToCharArray();
            Array.Reverse(chars);

            _ = int.TryParse(new string(chars), out int value);

            return value;
        }
    }

    internal class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    internal class Utils
    {
        public static string PrintNode(ListNode listNode, bool addDelimiter = true)
        {
            StringBuilder sb = new();
            sb.Append(listNode.val);

            if (listNode.next != null)
            {
                if (addDelimiter == true)
                {
                    sb.Append(",");
                }

                sb.Append(PrintNode(listNode.next, addDelimiter));
            }

            return sb.ToString();
        }

        public static ListNode CreateListNode(int value)
        {
            char[] chars = value.ToString().ToCharArray();

            ListNode result = new();

            for (int i = 0; i < chars.Length; i++)
            {
                _ = int.TryParse(char.ToString(chars[i]), out int charValue);
                if (i == 0)
                {
                    result = new ListNode(charValue);
                }
                else
                {
                    result = new ListNode(charValue, result);
                }
            }

            return result;
        }
    }

}
