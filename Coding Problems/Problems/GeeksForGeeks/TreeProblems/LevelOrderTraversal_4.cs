namespace Coding_Problems.Problems.GeeksForGeeks.TreeProblems
{
    internal class LevelOrderTraversal_4 : IProblem, IGeeksForGeeksProblem
    {
        public int Id { get; } = 4;
        public string Name { get; } = "Level Order Traversal";
        public string Difficulty { get; } = "Easy";

        public void Solve()
        {
            // Example 1
            Node e1Leaf1 = new(3);
            Node e1Leaf2 = new(2);
            Node e1Root = new(1, e1Leaf1, e1Leaf2);
            Solve(1, e1Root);

            // Example 2
            Node e2Leaf1 = new(40);
            Node e2Leaf2 = new(60);
            Node e2Lvl1RootL = new(20, e2Leaf1, e2Leaf2);
            Node e2Leaf3 = new(30);
            Node e2Root = new(10, e2Lvl1RootL, e2Leaf3);
            Solve(2, e2Root);
        }

        private static void Solve(int exampleNum, Node root)
        {
            List<int> orderedOutput = LevelOrderTraversalSolution.LevelOrder(root);

            Console.WriteLine($"Example {exampleNum}):");
            Console.WriteLine($"  Output: [{string.Join(", ", orderedOutput)}]");
            Console.WriteLine();
        }
    }

    internal class LevelOrderTraversalSolution
    {
        public static List<int> LevelOrder(Node root)
        {

            // 1 get height of tree
            int height = TreeHeight(root);

            // 2 find way to print nodes at each level

            List<int> flatTree = [];

            for (int i = 0; i < height; i++)
            {
                PrintLevel(flatTree, root, i);
            }

            return flatTree;
        }

        private static int TreeHeight(Node root)
        {
            if (root == null) { return 0; }

            int leftHeight = TreeHeight(root.left!);
            int righHeight = TreeHeight(root.right!);

            return Math.Max(leftHeight, righHeight) + 1;
        }

        private static void PrintLevel(List<int> flattree, Node root, int level)
        {
            if (root == null) { return; }

            if (level == 0)
            {
                flattree.Add(root.data);
            }
            else
            {
                PrintLevel(flattree, root.left!, level - 1);
                PrintLevel(flattree, root.right!, level - 1);
            }
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
