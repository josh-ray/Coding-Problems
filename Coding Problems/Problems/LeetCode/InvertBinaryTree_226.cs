using Coding_Problems.Problems.LeetCode.UtilityClasses;

namespace Coding_Problems.Problems.LeetCode
{
    internal class InvertBinaryTree_226 : IProblem, ILeetCodeProblem
    {
        public int Id { get; } = 226;
        public string Name { get; } = "Invert Binary Tree";
        public string Difficulty { get; } = "Easy";

        public void Solve()
        {
            TreeNode ex1Leaf1 = new(1);
            TreeNode ex1Leaf2 = new(3);
            TreeNode ex1Leaf3 = new(6);
            TreeNode ex1Leaf4 = new(9);

            TreeNode ex1Lvl1Left = new(2, ex1Leaf1, ex1Leaf2);
            TreeNode ex1Lvl1Right = new(7, ex1Leaf3, ex1Leaf4);

            TreeNode rootEx1 = new(4, ex1Lvl1Left, ex1Lvl1Right);

            Solve(exampleNum: 1, rootEx1);
        }

        private static void Solve(int exampleNum, TreeNode root)
        {
            Console.WriteLine($"Example {exampleNum}):");
            Console.WriteLine($"  Input: root = {PrintTree(root)}");

            TreeNode result = InvertBinaryTreeSolution.InvertTree(root);
            
            Console.WriteLine($"  Output: {PrintTree(result)}");
            Console.WriteLine();
        }

        private static string PrintTree(TreeNode root){
            List<string> flatTree = [];
            PrintRoot(root, flatTree);
            return $"[{string.Join(",", flatTree)}]";
        }

        private static void PrintRoot(TreeNode root, List<string> flatTree){
            // Get tree height
            int height = GetTreeHeight(root);

            // print each level
            for(int i = 0; i < height; i++){
                PrintLevel(root, i, flatTree);
            }
        }

        private static int GetTreeHeight(TreeNode root){
            if (root == null) { return 0; }

            return Math.Max(GetTreeHeight(root.left!), GetTreeHeight(root.right!)) + 1;
        }

        private static void PrintLevel(TreeNode root, int level, List<string> flatTree){
            if (root == null) { return;}

            if (level == 0) {
                flatTree.Add(root.val.ToString());
            }
            else {
                PrintLevel(root.left!, level -1, flatTree);
                PrintLevel(root.right!, level -1, flatTree);
            }
        }
    }

    internal class InvertBinaryTreeSolution
    {
        public static TreeNode InvertTree(TreeNode root)
        {
            Invert(root);
            return root;
        }

        private static void Invert(TreeNode root){
            if (root == null) { return; }

            TreeNode temp = root.left!;
            root.left = root.right;
            root.right = temp;

            Invert(root.left!);
            Invert(root.right!);
        }
    }
}