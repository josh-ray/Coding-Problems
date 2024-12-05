namespace Coding_Problems.Problems.GeeksForGeeks.TreeProblems
{
    internal class InorderTraversal_1 : IProblem, IGeeksForGeeksProblem
    {
        public int Id { get; } = 1;
        public string Name { get; } = "Inorder Traversal";
        public string Difficulty { get; } = "Basic";

        public void Solve()
        {
            // Example 1
            Node e1RightLeaf = new (2);
            Node e1LeftLeaf = new (3);
            Node e1Root = new (1, e1LeftLeaf, e1RightLeaf);
            Solve(1, e1Root);

            // Example 2
            Node e2Leaf1 = new (40);
            Node e2Leaf2 = new (60);
            Node e2Level1RootL = new (20, e2Leaf1, e2Leaf2);
            Node e2Leaf3 = new (50);
            Node e2Level1RootR = new(30, e2Leaf3, null);
            Node e2Root = new(10, e2Level1RootL, e2Level1RootR);
            Solve(2, e2Root);
            
        }

        private static void Solve(int exampleNum, Node root)
        {
            List<int> orderedOutput = InorderTraversalSolution.InOrder(root);

            Console.WriteLine($"Example {exampleNum}):");
            Console.WriteLine($"  Output: [{string.Join(", ", orderedOutput)}]");
            Console.WriteLine();
        }
    }

    internal class InorderTraversalSolution
    {
        public static List<int> InOrder(Node root)
        {
            List<int> flatTree = [];

            Traverse(root, flatTree);

            return flatTree;
        }

        private static void Traverse(Node root, List<int> flattree)
        {
            if (root == null) { return; }
            Traverse(root.left!, flattree);
            flattree.Add(root.data);
            Traverse(root.right!, flattree);
        }
    }
}
