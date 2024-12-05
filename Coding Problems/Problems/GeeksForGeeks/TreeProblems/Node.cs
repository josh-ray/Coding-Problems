namespace Coding_Problems.Problems.GeeksForGeeks.TreeProblems
{
    internal class Node 
    {
        public int data;
        public Node? left;
        public Node? right;

        public Node(int key)
        {
            this.data = key;
            this.left = null;
            this.right = null;
        }

        public Node(int key, Node? left, Node? right)
        {
            this.data = key;
            this.left = left;
            this.right = right!;
        }
    }
}
