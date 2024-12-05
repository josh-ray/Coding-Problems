

namespace Coding_Problems.Problems.GeeksForGeeks.TreeProblems
{
    internal class PreorderTraversal_2 : IProblem, IGeeksForGeeksProblem
    {
        public int Id { get; } = 2;
        public string Name { get; } = "Preorder Traversal";
        public string Difficulty { get; } = "Basic";

        public void Solve()
        {
            // Example 1
            Node e1Leaf1 = new(4);
            Node e1Leaf2 = new(2);
            Node e1Level1RootL = new(4, e1Leaf1, e1Leaf2);
            Node e1Root = new(1, e1Level1RootL, null);
            Solve(1, e1Root);

            // Example 2
            Node e2Leaf1 = new(1);
            Node e2Lvl1RootL = new(3, null, e2Leaf1);
            Node e2Leaf2 = new(2);
            Node e2Lvl1RootR = new(2, e2Leaf2, null);
            Node e2Root = new(6, e2Lvl1RootL, e2Lvl1RootR);
            Solve(2, e2Root);
        }

        private static void Solve(int exampleNum, Node root)
        {
            List<int> orderedOutput = PreorderTraversalSolution.PreOrder(root);

            Console.WriteLine($"Example {exampleNum}):");
            Console.WriteLine($"  Output: [{string.Join(", ", orderedOutput)}]");
            Console.WriteLine();
        }
    }

    internal class PreorderTraversalSolution
    {
        public static List<int> PreOrder(Node root)
        {
            List<int> flatTree = [];

            Traverse(root, flatTree);

            return flatTree;
        }

        private static void Traverse(Node root, List<int> flattree)
        {
            if (root == null) { return; }
            flattree.Add(root.data);
            Traverse(root.left!, flattree);
            Traverse(root.right!, flattree);
        }
    }
}
