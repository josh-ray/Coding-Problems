namespace Coding_Problems.Problems.LeetCode
{
    internal class TwoSum_1 : IProblem, ILeetCodeProblem
    {
        public int Id { get; } = 1;
        public string Name { get; } = "Two Sum Problem";
        public string Difficulty { get; } = "Easy";

        public void Solve()
        {
            Solve(exampleNum: 1, nums: [2, 7, 11, 15], target: 9);
            Solve(exampleNum: 2, nums: [3, 2, 4], target: 6);
            Solve(exampleNum: 3, nums: [3, 3], target: 6);
        }

        private static void Solve(int exampleNum, int[] nums, int target)
        {
            int[] results = TwoSumSolution.TwoSum(nums, target);
            Console.WriteLine($"Example {exampleNum}):");
            Console.WriteLine($"  Input: nums = [{string.Join(",", nums)}], target = {target}");
            Console.WriteLine($"  Output: [{results[0]}, {results[1]}]");
        }
    }

    internal class TwoSumSolution
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return [i, j];
                    }
                }
            }
            return [];
        }
    }

}
