namespace Coding_Problems.Problems.LeetCode
{
    internal class MedianOfSortedArraysProblem_4 : IProblem, ILeetCodeProblem
    {
        public int Id { get; } = 4;
        public string Name { get; } = "Median of Two Sorted Arrays Problem";
        public string Difficulty { get; } = "Hard";

        public void Solve()
        {
            Solve(exampleNum: 1, nums1: [1, 3], nums2: [2]);
            Solve(exampleNum: 2, nums1: [1, 2], nums2: [3, 4]);
        }

        private static void Solve(int exampleNum, int[] nums1, int[] nums2)
        {
            double result = MedianOfSortedArraysSolution.FindMedianSortedArrays(nums1, nums2);

            Console.WriteLine($"Example {exampleNum}):");
            Console.WriteLine($"  Input: nums1 = [{string.Join(",", nums1)}], nums2 = [{string.Join(",", nums2)}]");
            Console.WriteLine($"  Output: median = {result}");
            Console.WriteLine();
        }
    }

    internal class MedianOfSortedArraysSolution
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] combined = new int[nums1.Length + nums2.Length];
            nums1.CopyTo(combined, 0);
            nums2.CopyTo(combined, nums1.Length);

            Array.Sort(combined);

            if (combined.Length % 2 == 0)
            { // Even
                int index = (combined.Length - 1) / 2; // drop the .5 to the base integer
                return (double)(combined[index] + combined[index + 1]) / 2; // Convert numerator to double for floating point
            }
            else
            {   // Odd
                return combined[combined.Length / 2];
            }
        }
    }
}
