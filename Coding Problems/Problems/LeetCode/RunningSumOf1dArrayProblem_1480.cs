namespace Coding_Problems.Problems.LeetCode
{
    internal class RunningSumOf1dArrayProblem_1480 : IProblem, ILeetCodeProblem
    {
        public int Id { get; } = 1480;
        public string Name { get; } = "Running Sum Of 1d Array Problem";
        public string Difficulty { get; } = "Easy";

        public void Solve()
        {
            Solve(exampleNum: 1, nums: [1, 2, 3, 4]);
            Solve(exampleNum: 2, nums: [1, 1, 1, 1, 1]);
            Solve(exampleNum: 3, nums: [3, 1, 2, 10, 1]);
        }

        private static void Solve(int exampleNum, int[] nums)
        {
            int[] result = RunningSumOf1dArraySolution.RunningSum(nums);

            Console.WriteLine($"Example {exampleNum}):");
            Console.WriteLine($"  Input: nums = {PrintArray(nums)}");
            Console.WriteLine($"  Output: {PrintArray(result)}");
            Console.WriteLine();
        }

        private static string PrintArray(int[] nums)
        {
            return $"[{string.Join(",", nums)}]";
        }
    }

    internal class RunningSumOf1dArraySolution
    {
        public static int[] RunningSum(int[] nums)
        {
            if (nums.Length <= 1) { return nums; }

            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] = nums[i] + nums[i - 1];
            }

            return nums;
        }
    }
}
